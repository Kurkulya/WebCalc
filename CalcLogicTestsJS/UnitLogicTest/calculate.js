var x = 0;
var y = 0;
var op = '+';

function fNum(but)
{
	form.resField.value += but.value; 
}

function fOper(but)
{
    if (but.value != '=')
    {
        x = form.resField.value;
        form.resField.value = "";
        op = but.value;
    }
    else
    {
        y = form.resField.value;
        form.resField.value = calculate(Number(x), Number(y), op);
    }
}

function calculate(x,y,op)
{
	var result = 0;

	if(op == '+')
		result = x + y;
	else if(op == '-')
		result = x - y;
	else if(op == '*')
		result = x * y;
	else if(op == '/')
		result = x / y;		
		
	return result;
}