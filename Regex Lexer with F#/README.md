# Regex Lexer with F#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- F# Language
## Topics
- Regular Expressions
- functional programming
- lexer
- computation expressions
## Updated
- 06/03/2011
## Description

<p>This lexer allows you to define your regular expression based rules in a very declarative way using F# computation expressions.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">fsharp</span>

<div class="preview">
<pre id="codePreview" class="js">open&nbsp;Lexer&nbsp;
let&nbsp;definitions&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;lexerDefinitions&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addNextlineDefinition&nbsp;<span class="js__string">&quot;NEWLINE&quot;</span>&nbsp;@<span class="js__string">&quot;(\n\r)|\n|\r&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addIgnoreDefinition&nbsp;<span class="js__string">&quot;WS&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__string">&quot;\s&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addDefinition&nbsp;<span class="js__string">&quot;LET&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;let&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addDefinition&nbsp;<span class="js__string">&quot;ID&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;(?i)[a-z][a-z0-9]*&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addDefinition&nbsp;<span class="js__string">&quot;FLOAT&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__string">&quot;[0-9]&#43;\.[0-9]&#43;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addDefinition&nbsp;<span class="js__string">&quot;INT&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;[0-9]&#43;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addDefinition&nbsp;<span class="js__string">&quot;OPERATOR&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@<span class="js__string">&quot;[&#43;*=!/&amp;|&lt;&gt;\^\-]&#43;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>With those defined you can execute the lexer with:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">fsharp</span>

<div class="preview">
<pre id="codePreview" class="js">open&nbsp;Lexer&nbsp;
let&nbsp;lex&nbsp;input&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;y&nbsp;=&nbsp;Lexer.tokenize&nbsp;definitions&nbsp;input&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;printfn&nbsp;<span class="js__string">&quot;%A&quot;</span>&nbsp;y&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">with</span>&nbsp;e&nbsp;-&gt;&nbsp;printf&nbsp;<span class="js__string">&quot;%s&quot;</span>&nbsp;e.Message&nbsp;
lex&nbsp;<span class="js__string">&quot;let&nbsp;a&nbsp;=&nbsp;5&quot;</span></pre>
</div>
</div>
</div>
<p>Which will result in:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">fsharp</span>

<div class="preview">
<pre id="codePreview" class="js">seq&nbsp;[&nbsp;
<span class="js__brace">{</span>name&nbsp;=&nbsp;<span class="js__string">&quot;LET&quot;</span>&nbsp;;text&nbsp;=&nbsp;<span class="js__string">&quot;let&quot;</span>;pos&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;column&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;line&nbsp;=&nbsp;<span class="js__num">0</span>;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">{</span>name&nbsp;=&nbsp;<span class="js__string">&quot;ID&quot;</span>;&nbsp;text&nbsp;=&nbsp;<span class="js__string">&quot;a&quot;</span>;&nbsp;pos&nbsp;=&nbsp;<span class="js__num">4</span>;&nbsp;column&nbsp;=&nbsp;<span class="js__num">4</span>;line&nbsp;=&nbsp;<span class="js__num">0</span>;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">{</span>name&nbsp;=&nbsp;<span class="js__string">&quot;OPERATOR&quot;</span>;&nbsp;text&nbsp;=&nbsp;<span class="js__string">&quot;=&quot;</span>;&nbsp;pos&nbsp;=&nbsp;<span class="js__num">6</span>;column&nbsp;=&nbsp;<span class="js__num">6</span>;&nbsp;line&nbsp;=&nbsp;<span class="js__num">0</span>;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">{</span>name&nbsp;=&nbsp;<span class="js__string">&quot;INT&quot;</span>;&nbsp;text&nbsp;=&nbsp;<span class="js__string">&quot;5&quot;</span>;pos&nbsp;=&nbsp;<span class="js__num">8</span>;column&nbsp;=&nbsp;<span class="js__num">8</span>;line&nbsp;=&nbsp;<span class="js__num">0</span>;<span class="js__brace">}</span>]</pre>
</div>
</div>
</div>
<p>The lexer&rsquo;s code is structured in three parts.&nbsp; The first part is a state monad using the F# computation expressions. This enables the declarative approach (seen above) to setup your lexer rules.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">fsharp</span>

<div class="preview">
<pre id="codePreview" class="js">module&nbsp;StateMonad&nbsp;
type&nbsp;State&lt;<span class="js__string">'s,'</span>a&gt;&nbsp;=&nbsp;State&nbsp;of&nbsp;(<span class="js__string">'s&nbsp;-&gt;&nbsp;('</span>a&nbsp;*'s))&nbsp;
let&nbsp;runState&nbsp;(State&nbsp;f)&nbsp;=&nbsp;f&nbsp;
type&nbsp;StateBuilder()&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;member&nbsp;b.Return(x)&nbsp;=&nbsp;State&nbsp;(fun&nbsp;s&nbsp;-&gt;&nbsp;(x,s))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;member&nbsp;b.Delay(f)&nbsp;=&nbsp;f()&nbsp;:&nbsp;State&lt;<span class="js__string">'s,'</span>a&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;member&nbsp;b.Zero()&nbsp;=&nbsp;State&nbsp;(fun&nbsp;s&nbsp;-&gt;&nbsp;((),s))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;member&nbsp;b.Bind(State&nbsp;p,rest)&nbsp;=&nbsp;State&nbsp;(fun&nbsp;s&nbsp;-&gt;&nbsp;let&nbsp;v,s2&nbsp;=&nbsp;p&nbsp;s&nbsp;<span class="js__operator">in</span>&nbsp;&nbsp;(runState&nbsp;(rest&nbsp;v))&nbsp;s2)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;member&nbsp;b.Get&nbsp;()&nbsp;=&nbsp;State&nbsp;(fun&nbsp;s&nbsp;-&gt;&nbsp;(s,s))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;member&nbsp;b.Put&nbsp;s&nbsp;=&nbsp;State&nbsp;(fun&nbsp;_&nbsp;-&gt;&nbsp;((),s))</pre>
</div>
</div>
</div>
<p>The second part are the combinators that are used to define your lexer rules.&nbsp; There are three main combinators:&nbsp;
<strong>AddDefinition</strong> which lets you define a name / regex pair, <strong>
AddIgnoreDefinition </strong>which lets you define characters which the lexer should ignore and
<strong>AddNextlineDefinition </strong>which lets you define what characters determine a new line.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">fsharp</span>

<div class="preview">
<pre id="codePreview" class="js">type&nbsp;LexDefinitions&nbsp;=&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>regexes&nbsp;:&nbsp;string&nbsp;list;&nbsp;
&nbsp;&nbsp;&nbsp;names&nbsp;:&nbsp;string&nbsp;list;&nbsp;
&nbsp;&nbsp;&nbsp;nextlines&nbsp;:&nbsp;bool&nbsp;list;&nbsp;
&nbsp;&nbsp;&nbsp;ignores&nbsp;:&nbsp;bool&nbsp;list;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
let&nbsp;buildDefinition&nbsp;name&nbsp;pattern&nbsp;nextLine&nbsp;ignore&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;state&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let!&nbsp;x&nbsp;=&nbsp;state.Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;state.Put&nbsp;<span class="js__brace">{</span>&nbsp;regexes&nbsp;=&nbsp;x.regexes&nbsp;@&nbsp;&nbsp;[sprintf&nbsp;@<span class="js__string">&quot;(?&lt;%s&gt;%s)&quot;</span>&nbsp;name&nbsp;pattern];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;names&nbsp;=&nbsp;x.names&nbsp;@&nbsp;[name];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nextlines&nbsp;&nbsp;=&nbsp;x.nextlines&nbsp;@&nbsp;[nextLine];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ignores&nbsp;=&nbsp;x.ignores&nbsp;@&nbsp;[ignore]<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
let&nbsp;addDefinition&nbsp;name&nbsp;pattern&nbsp;=&nbsp;buildDefinition&nbsp;name&nbsp;pattern&nbsp;false&nbsp;false&nbsp;
let&nbsp;addIgnoreDefinition&nbsp;name&nbsp;pattern&nbsp;=&nbsp;buildDefinition&nbsp;name&nbsp;pattern&nbsp;false&nbsp;true&nbsp;
let&nbsp;addNextlineDefinition&nbsp;name&nbsp;pattern&nbsp;=&nbsp;buildDefinition&nbsp;name&nbsp;pattern&nbsp;true&nbsp;true</pre>
</div>
</div>
</div>
<p>And the final part is the code that performs the tokenizing.&nbsp; It uses the Seq.unfold method to create the list of tokens.&nbsp; Unfold is a function which takes a single item and generates a list of new items from it.&nbsp; It is the opposite of Seq.fold
 which takes a list of items and turns it into a single item.&nbsp; The tokenize function used Seq.unfold to generate each token while keeping track of the current line number, position in that line and position in the input string.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">fsharp</span>

<div class="preview">
<pre id="codePreview" class="js">type&nbsp;Token&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;name&nbsp;:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;text:&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pos&nbsp;:int;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;column:&nbsp;int;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;line:&nbsp;int&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
let&nbsp;createLexDefs&nbsp;pb&nbsp;=&nbsp;&nbsp;(runState&nbsp;pb)&nbsp;<span class="js__brace">{</span>regexes&nbsp;=&nbsp;[];&nbsp;names&nbsp;=&nbsp;[];&nbsp;nextlines&nbsp;=&nbsp;[];&nbsp;ignores&nbsp;=&nbsp;[]<span class="js__brace">}</span>&nbsp;|&gt;&nbsp;snd&nbsp;
let&nbsp;tokenize&nbsp;lexerBuilder&nbsp;(str:string)&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;patterns&nbsp;=&nbsp;createLexDefs&nbsp;lexerBuilder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;combinedRegex&nbsp;=&nbsp;&nbsp;Regex(List.fold&nbsp;(fun&nbsp;acc&nbsp;reg&nbsp;-&gt;&nbsp;acc&nbsp;&#43;&nbsp;<span class="js__string">&quot;|&quot;</span>&nbsp;&#43;&nbsp;reg)&nbsp;(List.head&nbsp;patterns.regexes)&nbsp;(List.tail&nbsp;patterns.regexes))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;nextlineMap&nbsp;=&nbsp;List.zip&nbsp;patterns.names&nbsp;patterns.nextlines&nbsp;|&gt;&nbsp;Map.ofList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;ignoreMap&nbsp;=&nbsp;List.zip&nbsp;patterns.names&nbsp;patterns.ignores&nbsp;|&gt;&nbsp;Map.ofList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;tokenizeStep&nbsp;(pos,line,lineStart)&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;pos&nbsp;&gt;=&nbsp;str.Length&nbsp;then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;None&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;getMatchedGroupName&nbsp;(grps:GroupCollection)&nbsp;names&nbsp;=&nbsp;List.find&nbsp;(fun&nbsp;(name:string)&nbsp;-&gt;&nbsp;grps.[name].Length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;names&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;match&nbsp;combinedRegex.Match(str,&nbsp;pos)&nbsp;<span class="js__statement">with</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;mt&nbsp;when&nbsp;mt.Success&nbsp;&amp;&amp;&nbsp;pos&nbsp;=&nbsp;mt.Index&nbsp;&nbsp;-&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;groupName&nbsp;=&nbsp;getMatchedGroupName&nbsp;mt.Groups&nbsp;patterns.names&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;column&nbsp;=&nbsp;mt.Index&nbsp;-&nbsp;lineStart&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;nextPos&nbsp;=&nbsp;pos&nbsp;&#43;&nbsp;mt.Length&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;(nextLine,&nbsp;nextLineStart)&nbsp;=&nbsp;<span class="js__statement">if</span>&nbsp;nextlineMap.Item&nbsp;groupName&nbsp;then&nbsp;(line&nbsp;&#43;&nbsp;<span class="js__num">1</span>,&nbsp;nextPos)&nbsp;<span class="js__statement">else</span>&nbsp;(line,lineStart)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;token&nbsp;=&nbsp;<span class="js__statement">if</span>&nbsp;ignoreMap.Item&nbsp;groupName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;then&nbsp;None&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;Some&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name&nbsp;=&nbsp;groupName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;text&nbsp;=&nbsp;mt.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pos&nbsp;=&nbsp;pos;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;line&nbsp;=&nbsp;line;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;column&nbsp;=&nbsp;column;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Some(token,&nbsp;(nextPos,&nbsp;nextLine,&nbsp;nextLineStart))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;otherwise&nbsp;-&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;textAroundError&nbsp;=&nbsp;str.Substring(pos,&nbsp;min&nbsp;(pos&nbsp;&#43;&nbsp;<span class="js__num">5</span>)&nbsp;str.Length)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;raise&nbsp;(ArgumentException&nbsp;(sprintf&nbsp;<span class="js__string">&quot;Lexing&nbsp;error&nbsp;occured&nbsp;at&nbsp;line:%d&nbsp;and&nbsp;column:%d&nbsp;near&nbsp;the&nbsp;text:%s&quot;</span>&nbsp;line&nbsp;(pos&nbsp;-&nbsp;lineStart)&nbsp;textAroundError))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Seq.unfold&nbsp;tokenizeStep&nbsp;(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>)&nbsp;|&gt;&nbsp;Seq.filter&nbsp;(fun&nbsp;x&nbsp;-&gt;&nbsp;x.IsSome)&nbsp;|&gt;&nbsp;Seq.map&nbsp;(fun&nbsp;x&nbsp;-&gt;&nbsp;x.Value)</pre>
</div>
</div>
</div>
<p>Lastly, here are the unit tests written using <a href="http://xunit.codeplex.com/">
XUnit.Net</a>:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">fsharp</span>

<div class="preview">
<pre id="codePreview" class="js">module&nbsp;LexerFacts&nbsp;
open&nbsp;Xunit&nbsp;
open&nbsp;Lexer&nbsp;
open&nbsp;System.Linq&nbsp;
let&nbsp;simpleDefs&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;state&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addNextlineDefinition&nbsp;<span class="js__string">&quot;NextLine&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;/&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addIgnoreDefinition&nbsp;<span class="js__string">&quot;IgnoredSymbol&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;=&#43;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addDefinition&nbsp;<span class="js__string">&quot;String&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;[a-zA-Z]&#43;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addDefinition&nbsp;<span class="js__string">&quot;Number&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;\d&#43;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">do</span>!&nbsp;addDefinition&nbsp;<span class="js__string">&quot;Name&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;Matt&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
[&lt;Fact&gt;]&nbsp;
let&nbsp;Will_return_no_tokens_for_empty_string()&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;tokens&nbsp;=&nbsp;Lexer.tokenize&nbsp;simpleDefs&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__num">0</span>,&nbsp;tokens.Count())&nbsp;
&nbsp;&nbsp;
[&lt;Fact&gt;]&nbsp;
let&nbsp;Will_throw_exception_for_invalid_token()&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;tokens&nbsp;=&nbsp;Lexer.tokenize&nbsp;simpleDefs&nbsp;<span class="js__string">&quot;-&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;ex&nbsp;=&nbsp;Assert.ThrowsDelegateWithReturn(fun&nbsp;()&nbsp;-&gt;&nbsp;upcast&nbsp;tokens.Count())&nbsp;|&gt;&nbsp;Record.Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.NotNull(ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.True(ex&nbsp;:?&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ArgumentException.aspx" target="_blank" title="Auto generated link to System.ArgumentException">System.ArgumentException</a>)&nbsp;
&nbsp;&nbsp;
[&lt;Fact&gt;]&nbsp;
let&nbsp;Will_ignore_symbols_defined_as_ignore_symbols()&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;tokens&nbsp;=&nbsp;Lexer.tokenize&nbsp;simpleDefs&nbsp;<span class="js__string">&quot;=========&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__num">0</span>,&nbsp;tokens.Count())&nbsp;
&nbsp;&nbsp;
[&lt;Fact&gt;]&nbsp;
let&nbsp;Will_get_token_with_correct_position_and_type()&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;tokens&nbsp;=&nbsp;Lexer.tokenize&nbsp;simpleDefs&nbsp;<span class="js__string">&quot;1one=2=two&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;Number&quot;</span>,tokens.ElementAt(<span class="js__num">2</span>).name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;2&quot;</span>,tokens.ElementAt(<span class="js__num">2</span>).text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__num">5</span>,tokens.ElementAt(<span class="js__num">2</span>).pos)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__num">5</span>,tokens.ElementAt(<span class="js__num">2</span>).column)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__num">0</span>,tokens.ElementAt(<span class="js__num">2</span>).line)&nbsp;
&nbsp;&nbsp;
[&lt;Fact&gt;]&nbsp;
let&nbsp;Will_tokenize_string_with_alernating_numbers_and_strings()&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;tokens&nbsp;=&nbsp;Lexer.tokenize&nbsp;simpleDefs&nbsp;<span class="js__string">&quot;1one2two&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;1&quot;</span>,tokens.ElementAt(<span class="js__num">0</span>).text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;one&quot;</span>,tokens.ElementAt(<span class="js__num">1</span>).text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;2&quot;</span>,tokens.ElementAt(<span class="js__num">2</span>).text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;two&quot;</span>,tokens.ElementAt(<span class="js__num">3</span>).text)&nbsp;
&nbsp;&nbsp;
[&lt;Fact&gt;]&nbsp;
let&nbsp;Will_increment_line_with_newline_symbol()&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;tokens&nbsp;=&nbsp;Lexer.tokenize&nbsp;simpleDefs&nbsp;<span class="js__string">&quot;1one/2two&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;Number&quot;</span>,tokens.ElementAt(<span class="js__num">2</span>).name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;2&quot;</span>,tokens.ElementAt(<span class="js__num">2</span>).text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__num">5</span>,tokens.ElementAt(<span class="js__num">2</span>).pos)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__num">0</span>,tokens.ElementAt(<span class="js__num">2</span>).column)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__num">1</span>,tokens.ElementAt(<span class="js__num">2</span>).line)&nbsp;
&nbsp;&nbsp;
[&lt;Fact&gt;]&nbsp;
let&nbsp;Will_give_priority_to_lexer_definitions_defined_earlier()&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;let&nbsp;tokens&nbsp;=&nbsp;Lexer.tokenize&nbsp;simpleDefs&nbsp;<span class="js__string">&quot;Matt&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Assert.Equal(<span class="js__string">&quot;String&quot;</span>,tokens.ElementAt(<span class="js__num">0</span>).name)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><span style="font-size:large">Read more from <a href="http://matthewmanela.com/">
Matthew Manela</a>&nbsp;at his <a href="http://matthewmanela.com/">blog</a>...</span></div>
