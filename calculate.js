function showResult()
{
	var x = form.xField.value;
	var y = form.yField.value;
	var op = form.opField.value;
	var res = calculate(Number(x),Number(y),op);
	form.resField.value = res;
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