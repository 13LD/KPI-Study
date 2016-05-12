package com.company;

/**
 * Created by lysogordima on 12.05.16.
 */
public class ConcreteCommand2 implements IExecutor {
    private Commands com;
    public ConcreteCommand2(Commands com){
        this.com = com;
    }
    public void execute(){
        com.advancedUserExec();
    }
}
