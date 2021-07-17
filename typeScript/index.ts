// generics
class MyClass<T> {
    constructor(public value: T) {
    }
}

let x: MyClass<number> = new MyClass(11)

// tuples
type MyArray = [number, string, boolean?];

const myArr: MyArray[] = [];

myArr.push([1, "11", true])
myArr.push([1, "11"])

// Arrays

const arr: Person[] = [];

arr.push({
    first: "Bill",
    last: "Bush"
});
arr.push({name: "Bill", sName: "Bush"}); // error
arr.push(true); // error

//-----
function pow(b, e): number {
    return Math.pow(b, e);
}

let res = pow(34, '222'); // error

//-----
interface Person {
    first: string,
    last: string,

    [key: string]: any
}

const person1: Person = {
    first: 'Jeff',
    last: 'Delaney'
}

const person2: Person = {
    first: 'Usain',
    last: 'Bolt',
    fast: true
}
//-----
type Style = 'bold' | 'italic' | 23;

let font: Style;

font = 23;
