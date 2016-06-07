package com.company;

public class Main {

    public static void main(String[] args) {
        Commands commands = new Commands();

        ConcreteCommand1 concreteCommand1 = new ConcreteCommand1(commands);
        ConcreteCommand2 concreteCommand2 = new ConcreteCommand2(commands);
        ConcreteCommand3 concreteCommand3 = new ConcreteCommand3(commands);

        Invoker invoker = new Invoker();
        invoker.takeExecutor(concreteCommand1);
        invoker.takeExecutor(concreteCommand2);
        invoker.takeExecutor(concreteCommand3);


        invoker.placeExecutor();

    }
}
