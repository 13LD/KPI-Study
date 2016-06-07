package com.company;

/**
 * Created by lysogordima on 20.05.16.
 */
public class ConcreteCommand3 implements IExecutor {
    private Commands com;
    public ConcreteCommand3(Commands com){
        this.com = com;
    }
    public void execute(){
        com.studentExecution();
    }
}
