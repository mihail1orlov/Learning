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
