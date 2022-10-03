-- Create Items
CREATE TABLE IF NOT EXISTS FriendRequests
(
    Id          serial primary key,
    SenderId    int,
    SendToId    int,
    RequestDate date not null
);
TRUNCATE TABLE FriendRequests;
INSERT INTO FriendRequests (SenderId, SendToId, RequestDate)
VALUES (1, 2, '2016_06-01'),
       (1, 3, '2016_06-01'),
       (1, 4, '2016_06-01'),
       (2, 3, '2016_06-02'),
       (3, 4, '2016_06-09');

CREATE TABLE IF NOT EXISTS RequestAccepted
(
    Id          serial primary key,
    RequesterId int,
    AccepterId  int,
    AcceptDate  date not null
);
TRUNCATE TABLE RequestAccepted;
INSERT INTO RequestAccepted (RequesterId, AccepterId, AcceptDate)
VALUES (1, 2, '2016_06-03'),
       (1, 3, '2016_06-08'),
       (2, 3, '2016_06-08'),
       (3, 4, '2016_06-09'),
       (3, 4, '2016_06-10');

-- Write a query to find the overall acceptance rate of requests rounded to 2 decimals, which is the number of acceptance divide the number of requests
SELECT round(
               nullif(
                               (SELECT count(distinct (RequesterId, AccepterId))
                                FROM RequestAccepted) * 1.0 /
                               (SELECT count(distinct (SenderId, SendToId))
                                FROM FriendRequests), 0.00
                   ):: decimal
           , 2)::text accept_rate;


-- Remove Data
DROP TABLE FriendRequests, RequestAccepted;