# This is a study project (Header 1)
***

[google search](https://google.com)

just a text

Line (like a header 2)
---
* item:

```c#
using System.IO;

namespace CsvReaderApp
{
    class Program
    {
        static void Main()
        {
            var path = @"../../../data/data.csv";
            var lines = File.ReadAllLines(path);
            var cells = new CsvReader(new StringConverter()).Read<double>(lines);
        }
    }
}
```

```json
{
  "firstName": "John",
  "lastName": "Smith",
  "isAlive": true,
  "age": 27,
  "address": {
    "streetAddress": "21 2nd Street",
    "city": "New York",
    "state": "NY",
    "postalCode": "10021-3100"
  },
  "phoneNumbers": [
    {
      "type": "home",
      "number": "212 555-1234"
    },
    {
      "type": "office",
      "number": "646 555-4567"
    }
  ],
  "children": [],
  "spouse": null
}
```


## List (Header 2)
* Item 1
* Item 2

Example:
![hey](readmeMdImg/test.img)

|00|01|02|
|-:|-:|-:|
|00010|000011|00000000012|


<p align="center">
  <img src="readmeMdImg/test.img" width=384 height=384/>
</p> 

Regular **Markdown** here.

<div hidden>

@startuml firstDiagram

Alice -> Bob: Hello
Bob -> Alice: Hi!
		
@enduml

</div>
