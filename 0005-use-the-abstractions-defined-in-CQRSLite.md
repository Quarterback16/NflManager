# 5. Use the abstrations defined in CQRSLite

Date: 2017-04-13 

## Status

Accepted

## Context

In an Event driven approach we need a way to define Commands events and messages.

## Decision

We will use the abstrations defined in the CQRSLite framework.  

    Has abstractions (Interfaces) for:-
	  * in process Service Bus
	  * Commands
	  * Events
	  * Aggregate Roots
	  * Messages
	  * the Read model Facade
	  * Event Store interface
	  * Snapshots


## Consequences

Common CQRS terminlogy will be applied.  Might flow on to having a separate read model.
Might flow on to having a separate Event Store.




