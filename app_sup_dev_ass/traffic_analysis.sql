-- Hour with highest average response time
SELECT strftime('%H', timestamp) AS hour, AVG(response_time_ms) AS avg_response_time
FROM request_logs
GROUP BY hour
ORDER BY avg_response_time DESC
LIMIT 1;

-- IPs with more than 100 requests with 429 status code
SELECT ip_address, COUNT(*) AS request_count
FROM request_logs
WHERE status_code = 429
GROUP BY ip_address
HAVING COUNT(*) > 100;

-- Total bytes sent for requests with response time > 500ms
SELECT SUM(bytes_sent) AS total_bytes
FROM request_logs
WHERE response_time_ms > 500;
