# 4. Use an in memory database for persistence

Date: 2017-04-13 

## Status

Accepted

## Context

We need a way to quicky access all the Domain events in order to service Queries.

## Decision

We will use an in memory database.  Initially perhaps a generic list, then if needed
maybe a Redis database. See the CQRS demo projects one which used simple List and another 
which used Redis.

## Consequences

Speed.  Limited by memory, however, we are not expecting a mega huge number of events.  

Initialisation via XML files will provide some natural backup and an easy way to 
change history by modifying events.


