# 3. Use a Unix style Command Line interface for the presentation layer

Date: 2017-04-13 

## Status

Accepted

## Context

We need a way to load up the system with sets of commands generated from Domain events.

## Decision

We will use a unix style command interface ala adr-tools.  

    For example: nmgr load [FILENAME] to inject into the system a set of commands
	             nmgr projectRoster to produce a projection of the current state of the rosters
				 nmgr projectRoster 2017-01-01 projection at a certain date
				 nmgr help
				 nmgr help [COMMAND]

## Consequences

Greater velocity as the nicety of a GUI will not concern us.  

A GUI may be provided later if nmgr goes into production to enable simple monitoring.


