kirill@MacBook-Pro-Kirill db_cp % ab -c 10 -n 1000 http://localhost:8080/api/v1/users
This is ApacheBench, Version 2.3 <$Revision: 1901567 $>
Copyright 1996 Adam Twiss, Zeus Technology Ltd, http://www.zeustech.net/
Licensed to The Apache Software Foundation, http://www.apache.org/

Benchmarking localhost (be patient)
Completed 100 requests
Completed 200 requests
Completed 300 requests
Completed 400 requests
Completed 500 requests
Completed 600 requests
Completed 700 requests
Completed 800 requests
Completed 900 requests
Completed 1000 requests
Finished 1000 requests


Server Software:        nginx/1.23.3
Server Hostname:        localhost
Server Port:            8080

Document Path:          /api/v1/users
Document Length:        185 bytes

Concurrency Level:      10
Time taken for tests:   8.461 seconds
Complete requests:      1000
Failed requests:        0
Total transferred:      351000 bytes
HTML transferred:       185000 bytes
Requests per second:    118.19 [#/sec] (mean)
Time per request:       84.606 [ms] (mean)
Time per request:       8.461 [ms] (mean, across all concurrent requests)
Transfer rate:          40.51 [Kbytes/sec] received

Connection Times (ms)
              min  mean[+/-sd] median   max
Connect:        0    0   0.1      0       1
Processing:    20   69 185.7     48    1907
Waiting:       17   66 185.5     45    1905
Total:         20   69 185.7     48    1907

Percentage of the requests served within a certain time (ms)
  50%     48
  66%     52
  75%     55
  80%     57
  90%     64
  95%     73
  98%    106
  99%   1729
 100%   1907 (longest request)