import re
from collections import Counter

log_file = "nginx_access.log"
output_file = "results.txt"

pattern = re.compile(
    r'^(?P<ip>\S+) .* "(?P<method>\S+) .*" (?P<status>\d{3}) (?P<bytes>\d+|-)')

ip_counter = Counter()
total_requests = 0
error_requests = 0
get_bytes = 0
get_count = 0

with open(log_file, 'r') as f:
    for line in f:
        m = pattern.search(line)
        if m:
            ip = m.group('ip')
            method = m.group('method')
            status = int(m.group('status'))
            bytes_sent = int(m.group('bytes')) if m.group(
                'bytes').isdigit() else 0

            ip_counter[ip] += 1
            total_requests += 1

            if 400 <= status <= 599:
                error_requests += 1

            if method == 'GET':
                get_bytes += bytes_sent
                get_count += 1

with open(output_file, "w") as out:
    out.write("=== Task 1: Top IPs, Error %, Avg Response Size ===\n")
    out.write("Top 5 IP addresses by request count:\n")
    for ip, count in ip_counter.most_common(5):
        out.write(f"{ip}: {count} requests\n")

    error_percent = (error_requests / total_requests) * 100
    out.write(f"\nError request percentage (400-599): {error_percent:.2f}%\n")

    avg_response_size = get_bytes / get_count if get_count else 0
    out.write(
        f"Average response size for GET requests: {avg_response_size:.2f} bytes\n")
