package com.company;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by lysogordima on 12.05.16.
 */
public class Invoker {
    private List<IExecutor> executorsList = new ArrayList<IExecutor>();

    public void takeExecutor(IExecutor executor){
        executorsList.add(executor);
    }

    public void placeExecutor(){
        for (IExecutor executor : executorsList){
            executor.execute();
        }
        executorsList.clear();
    }
}
