class Animal {
  walking() {
    console.log("Animal is walking");
  }
}

class Tiger extends Animal {
  walking() {
    console.log("Tiger is walking with four legs");
  }
}

class Bear extends Animal {
  walking() {
    console.log("Bear is walking with two legs");
  }
}

const animals = [new Tiger(), new Bear()];
animals.forEach((animal) => animal.walking());
