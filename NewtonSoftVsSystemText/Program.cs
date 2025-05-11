// See https://aka.ms/new-console-template for more information
using NewtonSoftVsSystemText;

Console.WriteLine("Hello, World!");

var superDuperNestedCake1 = new NestedCake
{
    Name = "Super Duper Nested Cake",
    Cakes = new List<NestedCake>
    {
        new NestedCake
        {
            Flavor = Flavours.Chocolate,
            Toppings = new List<string> { "Sprinkles", "Cherries" }
        },
        new NestedCake
        {
            Flavor = Flavours.Vanilla,
            Toppings = new List<string> { "Chocolate Chips", "Whipped Cream" }
        }
    }
};

var superDuperNestedCake2 = new NestedCake
{
    Name = "Super Duper Nested Cake 2",
    Toppings = new List<string> { "Hazelnuts","Cashews", "Almonds" },
    Cakes = new List<NestedCake>
    {
        new NestedCake
        {
            Flavor = Flavours.RedVelvet,
            Toppings = new List<string> { "Pistachio", "Astros" }
        },
        new NestedCake
        {
            Flavor = Flavours.Lemon,
            Toppings = new List<string> { "Poppy Seeds", "White Chocolate Shavings" }
        }
    }
};

var serializedWithNewtonsoft = NewtonSoftinator.Serialize(superDuperNestedCake1);
var serializedWithSystemText = SystemTextinator.Serialize(superDuperNestedCake1);

//these deserialize fine...
var deserializedWithNewtonsoft = NewtonSoftinator.Deserialize<NestedCake>(serializedWithNewtonsoft);
var deserializedWithSystemText = SystemTextinator.Deserialize<NestedCake>(serializedWithSystemText);

//these will throw errors...
//var deserializedWithNewtonsoftAndInterface = NewtonSoftinator.Deserialize<ICake>(serializedWithNewtonsoft);
//var deserializedWithSystemTextAndInterface = SystemTextinator.Deserialize<ICake>(serializedWithSystemText);
//..........................

Console.WriteLine("Newtonsoft results...");
Console.WriteLine("-----------------------");
foreach (var  nestedCake in deserializedWithNewtonsoft.Cakes)
{
    Console.WriteLine(nestedCake.Flavor.ToString());
}

Console.WriteLine("============================================");

Console.WriteLine("System Text results...");
Console.WriteLine("-----------------------");
foreach (var nestedCake in deserializedWithSystemText.Cakes)
{
    Console.WriteLine(nestedCake.Flavor.ToString());
}

Console.WriteLine("============================================");

//Console.WriteLine("Newtonsoft and interface results...");
//Console.WriteLine("-----------------------");
//foreach (var nestedCake in ((NestedCake)deserializedWithSystemTextAndInterface).Cakes)
//{
//    Console.WriteLine(nestedCake.Flavor.ToString());
//}

//Console.WriteLine("============================================");

//Console.WriteLine("System Text and interface results...");
//Console.WriteLine("-----------------------");
//foreach (var nestedCake in ((NestedCake)deserializedWithSystemTextAndInterface).Cakes)
//{
//    Console.WriteLine(nestedCake.Flavor.ToString());
//}

//Console.WriteLine("============================================");

var myParty = new Party();

myParty.PartyDateTime = DateTime.Now;
myParty.AbstractCake = superDuperNestedCake2;
myParty.ConcreteCake = superDuperNestedCake2;

var serializedPartyWithNewtonsoft = NewtonSoftinator.Serialize(myParty);
var serializedPartyWithSystemText = SystemTextinator.Serialize(myParty);

//these deserialize correctly, because of concrete nested types:
var superSimpleDeserializedPartyWithNewtonsoft = NewtonSoftinator.Deserialize<SuperSimpleParty>(serializedPartyWithNewtonsoft);
var superSimpleDeserializedPartyWithSystemText = SystemTextinator.Deserialize<SuperSimpleParty>(serializedPartyWithSystemText);

//the following all don't, because of ICake interface:
var deserializedPartyWithNewtonsoft = NewtonSoftinator.Deserialize<Party>(serializedPartyWithNewtonsoft);
var deserializedPartyWithSystemText = SystemTextinator.Deserialize<Party>(serializedPartyWithSystemText);

var forgivingDeserializedPartyWithNewtonsoft = NewtonSoftinator.Deserialize<ForgivingParty>(serializedPartyWithNewtonsoft);
var forgivingDeserializedPartyWithSystemText = SystemTextinator.Deserialize<ForgivingParty>(serializedPartyWithSystemText);

var simpleDeserializedPartyWithNewtonsoft = NewtonSoftinator.Deserialize<SimpleParty>(serializedPartyWithNewtonsoft);
var simpleDeserializedPartyWithSystemText = SystemTextinator.Deserialize<SimpleParty>(serializedPartyWithSystemText);
//...........................

Console.WriteLine("Newtonsoft party results...");
Console.WriteLine("-----------------------------");
Console.WriteLine("____________");
Console.WriteLine("Concrete...");
Console.WriteLine("____________");
foreach (var topping in superSimpleDeserializedPartyWithNewtonsoft.ConcreteCake.Toppings)
{
    Console.WriteLine(topping);
}
Console.WriteLine("____________");
Console.WriteLine("Abstract...");
Console.WriteLine("____________");
//will throw error:
//foreach (var topping in ((NestedCake)deserializedPartyWithNewtonsoft.AbstractCake).Toppings)
//{
//    Console.WriteLine(topping);
//}

Console.WriteLine("============================================");

Console.WriteLine("System Text party results...");
Console.WriteLine("-----------------------------");
Console.WriteLine("____________");
Console.WriteLine("Concrete...");
Console.WriteLine("____________");
foreach (var topping in superSimpleDeserializedPartyWithSystemText.ConcreteCake.Toppings)
{
    Console.WriteLine(topping);
}
Console.WriteLine("____________");
Console.WriteLine("Abstract...");
Console.WriteLine("____________");
//will throw error:
//foreach (var topping in ((NestedCake)deserializedPartyWithSystemText.AbstractCake).Toppings)
//{
//    Console.WriteLine(topping);
//}

Console.WriteLine("============================================");

var partyWithEntertainment = new PartyWithEntertainment();
partyWithEntertainment.Entertainer = new Entertainer();

var serializedPartyWithEntertainmentAndNewtonsoft = NewtonSoftinator.Serialize(partyWithEntertainment);
var serializedPartyWithEntertainmentAndSystemText = SystemTextinator.Serialize(partyWithEntertainment);

//these also don't deserialize, despite the property being in the interface:
var deserializedPartyWithEntertainmentAndNewtonsoft = NewtonSoftinator.Deserialize<PartyWithEntertainment>(serializedPartyWithEntertainmentAndNewtonsoft);
var deserializedPartyWithEntertainmentAndSystemText = SystemTextinator.Deserialize<PartyWithEntertainment>(serializedPartyWithEntertainmentAndSystemText);

Console.WriteLine($"Newtonsoft party entertainer: {deserializedPartyWithEntertainmentAndNewtonsoft.Entertainer.Name}");
Console.WriteLine($"SystemText party entertainer: {deserializedPartyWithEntertainmentAndNewtonsoft.Entertainer.Name}");