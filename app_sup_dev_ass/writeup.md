Task 2 – Bug Fixes and Improvements
In Task 2, we implemented a log monitoring script that analyzes logs in a 5-minute rolling window to identify high error rates. Initially, there were bugs related to:

Timestamp Parsing:
The earlier implementation failed to handle timezone offsets properly. The log format [dd/Mon/yyyy:HH:MM:SS +zzzz] was correctly parsed using Python’s datetime.strptime() function with %z to accurately account for the timezone.

Time Window Calculation:
The time difference between logs and the current window was previously calculated imprecisely. This was fixed using:

python
Copy
Edit
time_diff_minutes = (timestamp - current_window_start).total_seconds() / 60
which accurately converts seconds to minutes, ensuring consistent rolling window logic.

Resetting the Window:
The monitoring logic was updated to reset the request and error counters when the time window exceeds 5 minutes. This allows real-time error rate detection and alert generation when the error percentage crosses the defined threshold (10%).

These changes resulted in a more stable and accurate error rate alerting mechanism.

Task 3 – Attack Detection Explanation
The goal of Task 3 was to identify potential denial-of-service (DoS) attacks or abusive behavior based on high-frequency requests from the same IP address.

Approach:
Each log line is parsed to extract the IP address and the timestamp of the request.

A dictionary (defaultdict(list)) is used to store all timestamps for each IP address.

The timestamps are sorted for each IP, and a sliding window technique is used:

For every sequence of 10 requests by the same IP, we check if the time between the first and tenth request is less than 10 seconds.

If yes, the IP is flagged as suspicious, indicating possible abuse or automated bot traffic.

This script helps detect brute-force attempts or scraping bots effectively, making it easier to block malicious IPs or set up automated mitigation strategies like CAPTCHA challenges or firewall rules.

Task 5 – CDN Performance Optimization (Optional)
To improve CDN and application layer performance, the following recommendations are made based on the analysis:

1. Aggressive Rate-Limiting:
   Implement IP-based rate-limiting for:

IPs that exceed a threshold of requests within a short time (as identified in Task 3).

IPs returning 429 Too Many Requests errors frequently (as identified in SQL query analysis).

This will prevent abuse and reduce backend load.

2. Caching Optimization:
   Enable cache-control headers with longer TTL (Time to Live) for static assets like JS, CSS, images.

Use ETag or Last-Modified headers to reduce redundant requests.

Leverage edge caching and CDN rules to bypass the origin for frequently accessed content.

3. Monitoring and Adaptation:
   Use tools like Grafana, Prometheus, or ELK to visualize traffic patterns and update CDN configurations dynamically.

By combining these approaches, overall latency and server load can be significantly reduced while maintaining security and performance.
