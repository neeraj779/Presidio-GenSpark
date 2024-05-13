# REST API Notes (https://restfulapi.net/)

## Introduction to REST API
- **REST (REpresentational State Transfer)** is an architectural style for distributed hypermedia systems.
- Widely used for building web-based APIs.
- Not a protocol or standard, but an architectural style.

## Six Guiding Principles of REST
- **Uniform Interface:**
  - Identifying resources uniquely.
  - Manipulating resources through representations.
  - Self-descriptive messages.
  - Hypermedia as the engine of application state.
- **Client-Server:**
  - Separation of concerns for better scalability.
- **Stateless:**
  - Each request must contain all necessary information.
- **Cacheable:**
  - Responses can be labeled as cacheable.
- **Layered System:**
  - Allows hierarchical layers for better organization.
- **Code on Demand (Optional):**
  - Allows client functionality extension by executing downloaded code.

## What is a Resource?
- Key abstraction in REST.
- Can be any identifiable piece of information.
- Includes data, metadata, and hypermedia links.

## Resource Methods
- Used for transitioning between resource states.
- Not necessarily tied to HTTP methods.

## REST and HTTP are Not the Same
- REST principles are broader than just HTTP.
- Following the six guiding principles defines a RESTful interface.

## Summary
- REST accesses data and functionality via URIs.
- Resources are acted upon using well-defined operations.
- Resources are decoupled from their representation.
- Standardized interface and protocol (usually HTTP) for exchanging representations.
- Metadata controls caching, error detection, negotiation, authentication.
- Every interaction must be stateless for simplicity, lightweight, and speed.
