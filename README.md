# Answer for questions

1. What is your favourite design pattern, and why?
I like 'Strategy' design pattern because we can separate algorithm as strategy interface from class and when the algorithm is changed, the class does not need to be changed. 

2. For your favourite programming language, tell me about a new (or upcoming) language feature that has you excited. Why is it exciting for you?
My favourite language is C#. It is easy to lean and develop web, desktop for game applications because there are lots of microsoft documentation, templates and suport base class libraries including Linq and entity framework. Moreover more new features for making code easier is coming like a 'a ??= b' which equals to 'if(a == null) a= b;'. 

3. What do you NOT like to see when you're reviewing your own of another colleague's code?
When I review the code, its better to have some context to help the review. So I like developers to put some explination when the PR has been made. 

4. Tell me about a time you fixed a performance issue.
I had one example for performance issue to update big customer data and include sending email notification for the feature.
Firstly customer support found the issue. 
Secondly I verified performance insights dashboad and cloudwatch in AWS to identify and investigate where/why the issue has occurred.
Then I found the issue and reason. However proper fix to address the issue, code needs to be changed, so we have added to new instance for temporaly solution.
After that, I have changed the code to separate sending email notification part to run backgound task and deployed production environment.

