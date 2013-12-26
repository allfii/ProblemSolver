/*
	creator: masphei @ 2013
	email: masphei@gmail.com
	
	problem: There is a child running up a staircase with n steps. The child can hop either with 1 step, 2 steps, or 3 steps, or maybe n steps. Count how many possible ways the child can run up the stair.
	
	tag: dynammic programming, brute force
	
	follow up question:
	- is all the step of the staircase equal? yes
	- can the child go back a few hops and take another hop forward? no
	- is there any time limitation? no, code as fast as you can
	- is there any memory limitation? cheaper storage is better
*/

#include <iostream>
using namespace std;

#define STEP_HAPS 3
#define TOTAL_STEPS 50

int main(void);
int calculateWays(int steps, int stepHap, int total);

int main(void){
	int totalWays = 0;
	
	for (int i=0;i<TOTAL_STEPS;i++){
		totalWays += calculateWays(TOTAL_STEPS, i+1, 0);
	}
	
	cout<<"Total Ways = "<<totalWays<<endl;
}

int calculateWays(int steps, int stepHap, int total){
	if (steps < stepHap)
		return 0;
	else if(steps == stepHap)
		return total+1;
	else{
		return calculateWays(steps - stepHap, stepHap, total+1);
	}
}
