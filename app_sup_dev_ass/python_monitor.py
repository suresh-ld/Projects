import re
from datetime import datetime


def parse_log_line(log_line):
    pattern = (
        r'(\d+\.\d+\.\d+\.\d+)'
        r' - (\w+)'
        r' \[(\d{2}/\w{3}/\d{4}:\d{2}:\d{2}:\d{2} \+\d{4})\]'
        r' "([^"]+)"'
        r' "([^"]+)"'
        r' (\d+)'
        r' (\d+)'
        r' (\d+)'
    )
    match = re.match(pattern, log_line)
    if not match:
        return None

    ip, action, timestamp_str, domain, request, status_str, bytes_sent_str, unknown_str = match.groups()
    try:
        timestamp = datetime.strptime(timestamp_str, '%d/%b/%Y:%H:%M:%S %z')
    except ValueError:
        return None

    return {
        'ip': ip,
        'action': action,
        'timestamp': timestamp,
        'domain': domain,
        'request': request,
        'status': int(status_str),
        'bytes_sent': int(bytes_sent_str),
        'unknown': int(unknown_str)
    }


def is_error_status(status):
    return 400 <= status <= 599


def monitor_logs(log_file):
    window_size_minutes = 5
    error_threshold = 0.10

    current_window_start = None
    window_requests = 0
    window_errors = 0

    with open(log_file, 'r') as f:
        for line in f:
            log_data = parse_log_line(line.strip())
            if log_data is None:
                continue

            timestamp = log_data['timestamp']
            status = log_data['status']

            if current_window_start is None:
                current_window_start = timestamp

            time_diff_minutes = (
                timestamp - current_window_start).total_seconds() / 60

            if time_diff_minutes > window_size_minutes:
                if window_requests > 0:
                    error_rate = window_errors / window_requests
                    if error_rate > error_threshold:
                        print(
                            f"Alert! Error rate {error_rate * 100:.2f}% exceeds threshold at {current_window_start}")
                current_window_start = timestamp
                window_requests = 0
                window_errors = 0

            window_requests += 1
            if is_error_status(status):
                window_errors += 1

    if window_requests > 0:
        error_rate = window_errors / window_requests
        if error_rate > error_threshold:
            print(
                f"Alert! Error rate {error_rate * 100:.2f}% exceeds threshold at {current_window_start}")


if __name__ == "__main__":
    monitor_logs('nginx_access.log')
