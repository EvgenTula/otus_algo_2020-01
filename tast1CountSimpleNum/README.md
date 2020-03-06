<table border="1">
<caption>Входные данные</caption>
<tr>
<th>№</th>
<th>Num</th>
<th>Pow</th>   
</tr>
<tr><td>Test #0</td><td>1,000000001</td><td>100000</td></tr>
<tr><td>Test #1</td><td>1,000000001</td><td>1000000</td></tr>
<tr><td>Test #2</td><td>1,000000001</td><td>10000000</td></tr>
<tr><td>Test #3</td><td>1,000000001</td><td>100000000</td></tr>
<tr><td>Test #4</td><td>1,000000001</td><td>1000000000</td></tr>   
</table>

<table border="1">
<caption>Итеративный -- n умножений (POWFullMultiplication)</caption>
<tr><th>Test</th><th>Time (ms)</th></tr>
<tr><th>Test #0</th><th>93</th></tr>
<tr><th>Test #1</th><th>214</th></tr>
<tr><th>Test #2</th><th>2225</th></tr>
<tr><th>Test #3</th><th>21198</th></tr>
<tr><th>Test #4</th><th>221436</th></tr>
</table>

<table border="1">
<caption>Через степень двойки с домножением (POWPartialMultiplication)</caption>
<tr><th>Test</th><th>Time (ms)</th></tr>
<tr><th>Test #0</th><th>16</th></tr>
<tr><th>Test #1</th><th>85</th></tr>
<tr><th>Test #2</th><th>298</th></tr>
<tr><th>Test #3</th><th>6138</th></tr>
<tr><th>Test #4</th><th>118098</th></tr>
</table>


<table border="1">
<caption>Через двоичное разложение показателя степени (POWDecomposition)</caption>
<tr><th>Test</th><th>Time (ms)</th></tr>
<tr><th>Test #0</th><th>10</th></tr>
<tr><th>Test #1</th><th>0</th></tr>
<tr><th>Test #2</th><th>0</th></tr>
<tr><th>Test #3</th><th>0</th></tr>
<tr><th>Test #4</th><th>0</th></tr>
</table>

