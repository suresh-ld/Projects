import re
from collections import defaultdict
from datetime import datetime

log_file = "nginx_access.log"
output_file = "results.txt"

pattern = re.compile(r'(?P<ip>\S+) - - \[(?P<time>[^]]+)]')
ip_hits = defaultdict(list)

with open(log_file, 'r') as f:
    for line in f:
        match = pattern.match(line)
        if match:
            ip = match.group("ip")
            time_str = match.group("time").split()[0]
            timestamp = datetime.strptime(time_str, "%d/%b/%Y:%H:%M:%S")
            ip_hits[ip].append(timestamp)

with open(output_file, "a") as out:
    out.write("\n=== Task 3: Potential Attacking IPs (10+ hits in 10 sec) ===\n")
    for ip, times in ip_hits.items():
        times.sort()
        for i in range(len(times) - 9):
            if (times[i + 9] - times[i]).total_seconds() < 10:
                out.write(
                    f"- {ip} with at least 10 hits between {times[i]} and {times[i+9]}\n")
                break
