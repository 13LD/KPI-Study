package com.company;

/**
 * Created by lysogordima on 12.05.16.
 */
public class ConcreteCommand1 implements  IExecutor{
    private Commands com;
    public ConcreteCommand1(Commands com){
        this.com = com;
    }
    public void execute(){
        com.simpleUserExec();
    }
}
