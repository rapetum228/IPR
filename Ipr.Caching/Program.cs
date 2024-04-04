using Ipr.Caching;
using Ipr.Caching.Memcached;
using Ipr.Caching.Redis;
using System.Text.Json;

Console.WriteLine();


var connection = RedisConnector.GetConnection();

var listService = new RedisListService<User>(connection);

var producer = new RedisProducer<User>(connection);

var consumer = new RedisConsumer<User>(connection);

var consumerGroup = new RedisConsumerGroup<User>(connection);



var i = 10;

while (i-- > 0)
{
    //await producer.AddToStreamAsync("user", new User()
    //{
    //    Name = "name-" + i,
    //    Surname = "surname-" + i
    //});
    await listService.ListLeftPush("user-list", new User
    {
        Name = "name-" + i,
        Surname = "surname-" + i
    });
}

i = 10;
//await consumerGroup.CreateConsumerGroupAsync("user", "user-group");
//await consumerGroup.CreateConsumerGroupAsync("user", "user-group-1");

while (i-- > 0)
{
   await listService.ListLeftPop("user-list");
    //var m = await consumerGroup.Read("user", "user-group", $"c-{i}");
   // await consumerGroup.Read("user", "user-group-1", $"c-{10-i}");
    //Console.WriteLine(JsonSerializer.Serialize(m));
}