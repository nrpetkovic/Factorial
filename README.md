# Factorial Calculator testing

![Factorial Calculator](/Images/FactorialCalculator.png)

A factorial calculator is easy to test since we are simply testing an input field for different input values and then verifying the output result.

To write test cases, we first need to specify boundary values – lower boundary and upper boundary. A lower boundary for the factorial calculator is 0. And upper boundary depends on an implementation, but with a small API testing using Postman we come to the value of 991 – upper boundary and maximum value for which backend returns the result.

![Boundary Value Analysis](/Images/BoundaryValueAnalysis.png)

With further exploratory testing, we analyze the behavior of the frontend and backend in more detail.

Backend returns factorial results in the range 0 – 991 and outside of it, for all valid and invalid inputs, 500 Internal Server Error is returned and no validation is implemented.

When it comes to validation, we can use frontend or backend validation, or we can use both. It depends on what we want. Frontend validation is important in terms of usability since it provides instant feedback, and it also stops unnecessary requests from being made. On the other side, frontend validation can be easily bypassed so good practice would be to also have backend validation implemented to ensure that the data coming in is indeed valid.

Returning 500 Internal Server Error messages by the backend is not looking nice, but we don’t know what the expected behavior was. Since our application is simple and we don’t have to perform any validations against the DB before a value is submitted, we can assume the behavior of the backend is correct, and we will focus on the frontend.

On the other side, the frontend handles all the validation. After some testing, we come to the following tables that explain frontend behavior:

![Frontend Behavior Analysis](/Images/FrontendBehaviorAnalysis.png)

Comparing backend and frontend behaviors we can notice that though the backend returns the factorial result for the numbers up to 991, the frontend shows Infinity result starting with number 171. If we assume that frontend and backend behavior should be aligned then this is a bug. The expected behavior would be to have a factorial result shown for all the numbers lesser than or equal to the upper boundary (991) and for all the higher numbers to have an Infinity message.

Another issue is that negative numbers are not validated, and nothing happens when a user submits them since the backend returns a 500 Internal Server Error.

One more thing worth mentioning related to the frontend behavior is that for numbers smaller and equal to 21, the calculator displays complete factorial results, while for numbers higher than that, we have results in scientific (exponential) notation (e+).

Now we can write test cases:

**Positive test cases**  
Submit integer value at lower boundary [0]  
Submit integer value at lower boundary+1 [1]  
Submit integer value at the upper boundary for the complete factorial result [21]  
Submit integer value at the lower boundary for the factorial result in exponential notation [22]  
Submit integer value at upper boundary-1 [990]  
Submit integer value at upper boundary [991]  

**Negative test cases**  
Submit integer value at upper boundary+1 [992]  
Submit integer value with leading 0  
Submit integer value with leading plus sign [+]  
Submit integer value with the leading minus sign [-]  
Submit integer value with leading spaces  
Submit a number with a decimal point  
Submit a number with the letter ‘e’ in it  
Submit alphabet characters  
Submit special characters  
Submit only space  
Submit with nothing entered  


According to these test cases, we will write automated tests that will cover all the scenarios. And since the validation is on the frontend side, most of the tests will be UI tests.

Issues are described in the following table.

![Issues](/Images/Issues.png)

The table above is not a very good way to describe and report issues, but since this is a simple application, we can use it in this case. In other situations, we can use some issue template like this:


## Issue Title
Title should be concise and specific and we should easily understand what is the problem.

## Issue Description
**Problem:** [Briefly describe the problem]

**Test data:**  
User:  
URL: 

**Steps to reproduce:**
1. Step 1
2. Step 2
3. Step 3  
--> Error
[annotated screenshot]  

**Expected behavior:**
