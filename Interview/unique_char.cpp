/*
	creator: masphei @2013
	email: masphei@gmail.com
	problem: implement an algorithm to determine if a string has all unique characters
	question: 
		- is the characters set ASCII? yes
		- is there any memory limitation? no
		- is there any time limitation? no
*/
#include <iostream>
using namespace std;

int main(void);
bool isUniqueChars(string str);

int main(void){
	string input = "";
	cout<<"Input string: ";
	cin>>input;
	if (isUniqueChars(input))
		cout<<"String is unique"<<endl;
	else
		cout<<"String is not unique"<<endl;
}

bool isUniqueChars(string str){
	if(str.length() > 256) return false;
	int val = 0;
	int check = 0;
	for (int i=0;i<str.length();i++){
		val = str[i] - 'a';
		if ((check & (1<<val)) > 0)
			return false;
		check |= (1<<val);
	}
	return true;
}