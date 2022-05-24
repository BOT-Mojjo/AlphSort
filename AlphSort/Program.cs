using System;
using System.Collections.Generic;
bool ongoing = true;
List<string> input = new List<string>(); 

Console.WriteLine("Write some Sentances. Or \"Run\" continue.");
while(ongoing){
    string inputStr = Console.ReadLine();
    if(inputStr.ToLower() == "run"){
        ongoing = false;
    } else {
        input.Add(inputStr);
    }
}

char[] alphabet = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö'};

string[,] output = new string[input.Count+1, 2];
output[input.Count, 1] = "100";
for(int i = 0; i < input.Count; i++){
    for (int ii = 0; ii < alphabet.Length+1; ii++){
        if(ii >= alphabet.Length){
            output[i,0] = input[i];
            output[i,1] = ii.ToString();
        }else if(input[i].ToLower().ToCharArray()[0] == alphabet[ii]){
            output[i,0] = input[i];
            output[i,1] = ii.ToString();
            break;
        }
    }
}
ongoing = true;
while(ongoing){
    bool fail = false;
    for(int i = 0; i < output.GetLength(0)-2; i++){
        if(int.Parse(output[i,1]) > int.Parse(output[i+1, 1])){
            string[] tempStorage = new string[2];
            tempStorage[0] = output[i,0]; //moves data to temp storage
            tempStorage[1] = output[i,1]; 
            output[i,0] = output[i+1,0]; //moves new data to previus location
            output[i,1] = output[i+1,1];
            output[i+1,0] = tempStorage[0];
            output[i+1,1] = tempStorage[1];
            fail = true;
        }
    }
    ongoing = fail;
}

for(int i = 0; i < output.GetLength(0)-1; i++){
    Console.WriteLine(i+1 + "-"+ output[i, 1] + ": " + output[i,0]);
}
Console.ReadLine();

