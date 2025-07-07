import asyncio

from azure.eventhub import EventData
from azure.eventhub.aio import EventHubProducerClient

EVENT_HUB_CONNECTION_STR = "Endpoint=sb://designpatternsandarchitecture.servicebus.windows.net/;SharedAccessKeyName=evhsp-appname-listen;SharedAccessKey=QtT9T5abt0xcCrZXP2Wpi8cXMDqQ15aHm+AEhJevzi4="
EVENT_HUB_NAME = "meueventhub"

async def run():
    # Create a producer client to send messages to the event hub.
    # Specify a connection string to your event hubs namespace and
    # the event hub name.
    producer = EventHubProducerClient.from_connection_string(
        conn_str=EVENT_HUB_CONNECTION_STR, eventhub_name=EVENT_HUB_NAME
    )
    async with producer:
        # Create a batch.
        event_data_batch = await producer.create_batch()

        # Add events to the batch.
        event_data_batch.add(EventData("First event "))
        event_data_batch.add(EventData("Second event"))
        event_data_batch.add(EventData("Third event"))

        for i in range(0, 11000):
            event_data_batch.add(EventData(f"Event {i}"))

        # Send the batch of events to the event hub.
        await producer.send_batch(event_data_batch)

asyncio.run(run())