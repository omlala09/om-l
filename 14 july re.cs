using System.Collections;
using static System.Net.Mime.MediaTypeNames;

//What is a Collection ?

//Suppose you have

string product1 = "Laptop";
string product2 = "Mouse";
string product3 = "Keyboard";

//Imagine you have 1000 products.

//Will you create

product1
product2
product3
...
product1000

//Impossible.

//Instead we use a collection.

//List<string> products = new List<string>();

//Now

products.Add("Laptop");
products.Add("Mouse");
products.Add("Keyboard");

//Memory becomes

products

0 -> Laptop

1 -> Mouse

2 -> Keyboard

//Now you have one object storing many values.

//Why not Array?

//Array

string[] products = new string[3];

//Only 3 values.

//Cannot automatically grow.

//List

List<string> products = new();

Keeps growing.

Laptop

Mouse

Keyboard

CPU

RAM

Monitor

Printer

...

//No size required.

This is exactly why the instructor preferred List over Array.

Generic Collection

The lecture explains

System.Collections.Generic

What does Generic mean?

Generic means

Only one datatype is allowed.

Example

List<int> numbers = new();

Allowed

numbers.Add(10);
numbers.Add(20);
numbers.Add(30);

Not allowed

numbers.Add("Hello");

Compiler Error

because

List<int>

means

Only integers

Similarly

List<string>

means

Only strings
Why <T> ?

//The instructor showed

List<T>

//What is T?

//T means

//Type

//When you write

List<string>

Compiler changes

T

↓

string

//When you write

//List<int>

//Compiler changes

T

↓

int

//That is why List is called a Generic Class.

//Dictionary

//Instructor explained

//Key → Value

//Let's build a real example.

//Instead of

1

2

3

we store

101 → Om

102 → Rahul

103 → Aman

//Code

Dictionary<int,string> students = new();

students.Add(101, "Om");
students.Add(102, "Rahul");
students.Add(103, "Aman");

Retrieve

Console.WriteLine(students[101]);

//Output

Om

Exactly what the lecture discusses when explaining key-value pairs and unique keys.

HashSet

HashSet removes duplicates automatically.

HashSet<string> names = new();

names.Add("Om");
names.Add("Rahul");
names.Add("Om");

Output

Om

Rahul

Only one "Om"

because duplicates are ignored.

The instructor specifically compares this behavior with List, which allows duplicate values.

Stack

Think about plates.

Plate 1

Plate 2

Plate 3

You always remove

Plate 3

first.

That's

LIFO

Last In First Out

Code

Stack<string> stack = new();

stack.Push("A");
stack.Push("B");
stack.Push("C");

Console.WriteLine(stack.Pop());

Output

C

This matches the plate analogy used in the lecture.

Async / Await

Suppose

Customer 1

↓

Database

takes

10 seconds.

Without Async

Customer 2 waits

Customer 3 waits

Customer 4 waits

With Async

Customer1

Customer2

Customer3

Customer4

↓

Database

↓

Responses independently

That's why Web APIs use

public async Task<IActionResult> GetProducts()
{
    var data = await db.Products.ToListAsync();

    return Ok(data);
}

The transcript explains async in terms of requests, threads, waiting, and avoiding thread starvation.

LINQ

Instead of writing loops

foreach(...)

you can write

var result = products.Where(p => p.Price > 1000);