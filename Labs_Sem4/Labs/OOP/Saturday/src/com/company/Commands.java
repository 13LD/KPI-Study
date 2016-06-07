package com.company;

import java.io.BufferedReader;
import java.io.Console;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by lysogordima on 12.05.16.
 */
public class Commands {
    public void deanExecution(){
        System.out.println("\n1.Made not full list of exemption students");
    }


    public void stewardExecution(){
        System.out.println("\n2.Made full list of exemption students and list of " +
                "documents that they must have ");
    }

    public void studentExecution(){
        System.out.println("\n3.Filed all documents ");
    }


}
