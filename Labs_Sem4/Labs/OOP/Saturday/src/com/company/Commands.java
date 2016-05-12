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
    public void simpleUserExec(){
        System.out.println("Connected as simple user ");
        System.out.println("\nSimple user without rights");
    }

    public void advancedUserExec(){
        System.out.println("Connected as advanced user ");
        System.out.println("\nChoose method\n1.Show information \n2.Input information to list \n3.Show info");
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        String input = null;
        try {
            input = br.readLine();
        } catch (IOException e) {
            e.printStackTrace();
        }
        System.out.println("No rights to show something, advanced user");
    }

    public void adminUserExec(){
        System.out.println("Connected as admin ");
        List<String> list_info = new ArrayList<String> ();

        System.out.println("\nChoose method\n1.Show information \n2.Input information to list \n3.Show users");
        BufferedReader br1 = new BufferedReader(new InputStreamReader(System.in));
        BufferedReader br2 = new BufferedReader(new InputStreamReader(System.in));

        int a = 0;
        try {
            a = Integer.parseInt(br1.readLine());
        } catch (IOException e) {
            e.printStackTrace();
        }
        if (a == 1)
            System.out.println("You have just entered admin room");
        else if (a == 2) {
            System.out.println ("\nList of info");
            list_info.add ("System information");
            list_info.add ("3rd is your info");
            for(int i = 0; i < list_info.size(); i++)
                System.out.println(list_info.get(i));
            System.out.println("Enter your info");
            String b = null;
            try {
                b = br2.readLine();
            } catch (IOException e) {
                e.printStackTrace();
            }
            list_info.add (b);
            System.out.println("\nList of info");
            for(int i = 0; i < list_info.size(); i++)
                System.out.println(list_info.get(i));
        } else if (a == 3) {
            System.out.println("Nothing to show :)");
        }
        else
            System.out.println ("Wrong input");
    }

}
