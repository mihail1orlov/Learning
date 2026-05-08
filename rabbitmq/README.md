# RabbitMQ

Messaging samples in `.NET` — default exchanges, direct exchanges, with and without Protobuf serialization.

## Projects

- [`RabbitMq_DefaultExchanges/`](RabbitMq_DefaultExchanges) — minimal `Publisher` + `Consumer` over the default exchange.
- [`RabbitMq_DirectExchange/`](RabbitMq_DirectExchange) — direct exchange with Protobuf-serialized payloads (`Common/`, `ProtobufConverter/`).
- [`RabbitMq_DirectExchange_/`](RabbitMq_DirectExchange_) — alternate take with explicit `DirecttExchangeConsumer.cs` / `DirecttExchangePublisher.cs` classes.

## Notes

- [`commands.txt`](commands.txt) — `docker run rabbitmq:management` and friends.
