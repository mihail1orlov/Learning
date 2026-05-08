# Kafka — references and primer

## References

- "Getting Started: Apache Kafka with .NET Core" by CodeOpinion:
  https://codeopinion.com/getting-started-apache-kafka-with-net-core/

- BigDataSchool wiki entry on Kafka (Russian):
  https://www.bigdataschool.ru/wiki/kafka

## Apache ZooKeeper — short version

ZooKeeper is an Apache Software Foundation project: a coordination
service that provides distributed synchronisation of small amounts of
data (configuration information, naming, leader election) for a group
of applications.

Internally it is a distributed key-value store. Strong consistency is
achieved through synchronous replication across the ensemble, plus
versioning, queues, and locking primitives. It keeps everything in RAM
and scales horizontally, which is what gives it its low-latency
characteristics.
