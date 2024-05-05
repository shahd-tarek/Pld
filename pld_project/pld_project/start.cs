
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF           =  0, // (EOF)
        SYMBOL_ERROR         =  1, // (Error)
        SYMBOL_WHITESPACE    =  2, // Whitespace
        SYMBOL_MINUS         =  3, // '-'
        SYMBOL_MINUSMINUS    =  4, // '--'
        SYMBOL_EXCLAMEQ      =  5, // '!='
        SYMBOL_NUM           =  6, // '#'
        SYMBOL_DOLLAR        =  7, // '$'
        SYMBOL_LPAREN        =  8, // '('
        SYMBOL_RPAREN        =  9, // ')'
        SYMBOL_TIMES         = 10, // '*'
        SYMBOL_COMMA         = 11, // ','
        SYMBOL_DOT           = 12, // '.'
        SYMBOL_DIV           = 13, // '/'
        SYMBOL_LBRACKET      = 14, // '['
        SYMBOL_RBRACKET      = 15, // ']'
        SYMBOL_PLUS          = 16, // '+'
        SYMBOL_PLUSPLUS      = 17, // '++'
        SYMBOL_LT            = 18, // '<'
        SYMBOL_LTEQ          = 19, // '<='
        SYMBOL_EQ            = 20, // '='
        SYMBOL_EQEQ          = 21, // '=='
        SYMBOL_GT            = 22, // '>'
        SYMBOL_GTEQ          = 23, // '>='
        SYMBOL_BREAK         = 24, // break
        SYMBOL_CASE1         = 25, // 'case1'
        SYMBOL_CASE2         = 26, // 'case2'
        SYMBOL_CASE3         = 27, // 'case3'
        SYMBOL_DEFAULT       = 28, // default
        SYMBOL_DG            = 29, // dg
        SYMBOL_DO            = 30, // do
        SYMBOL_DOUBLE        = 31, // double
        SYMBOL_ELSE          = 32, // else
        SYMBOL_FLOAT         = 33, // float
        SYMBOL_FORSTM        = 34, // forstm
        SYMBOL_GOODBYE       = 35, // goodbye
        SYMBOL_ID            = 36, // ID
        SYMBOL_IFSTM         = 37, // ifstm
        SYMBOL_INT           = 38, // int
        SYMBOL_ST            = 39, // st
        SYMBOL_STRING        = 40, // string
        SYMBOL_SWSTM         = 41, // swstm
        SYMBOL_WELCOME       = 42, // welcome
        SYMBOL_WHILE         = 43, // while
        SYMBOL_ARG           = 44, // <arg>
        SYMBOL_ASS           = 45, // <ass>
        SYMBOL_CALLMETH      = 46, // <callmeth>
        SYMBOL_CASEMINUSLIST = 47, // <case-list>
        SYMBOL_CODE          = 48, // <code>
        SYMBOL_COMMENT       = 49, // <comment>
        SYMBOL_COND          = 50, // <cond>
        SYMBOL_DATATYPE      = 51, // <datatype>
        SYMBOL_DIGIT         = 52, // <digit>
        SYMBOL_DOMINUSWHILE  = 53, // <do-while>
        SYMBOL_EXPR          = 54, // <expr>
        SYMBOL_FOR           = 55, // <for>
        SYMBOL_ID2           = 56, // <id>
        SYMBOL_IF            = 57, // <if>
        SYMBOL_INCR          = 58, // <incr>
        SYMBOL_METHOD        = 59, // <method>
        SYMBOL_MULTI         = 60, // <multi>
        SYMBOL_OP            = 61, // <op>
        SYMBOL_SEQUENCE      = 62, // <sequence>
        SYMBOL_SOURCECODE    = 63, // <sourcecode>
        SYMBOL_STR           = 64, // <str>
        SYMBOL_SWITCH        = 65, // <switch>
        SYMBOL_VALUE         = 66, // <value>
        SYMBOL_WHILE2        = 67  // <while>
    };

    enum RuleConstants : int
    {
        RULE_SEQUENCE_WELCOME_GOODBYE                         =  0, // <sequence> ::= welcome <sourcecode> goodbye
        RULE_SOURCECODE                                       =  1, // <sourcecode> ::= <comment>
        RULE_SOURCECODE2                                      =  2, // <sourcecode> ::= <code>
        RULE_SOURCECODE3                                      =  3, // <sourcecode> ::= <comment> <code> <sourcecode>
        RULE_COMMENT_DOLLAR                                   =  4, // <comment> ::= '$' <id>
        RULE_ID_ID                                            =  5, // <id> ::= ID
        RULE_CODE                                             =  6, // <code> ::= <ass>
        RULE_CODE2                                            =  7, // <code> ::= <switch>
        RULE_CODE3                                            =  8, // <code> ::= <if>
        RULE_CODE4                                            =  9, // <code> ::= <for>
        RULE_CODE5                                            = 10, // <code> ::= <while>
        RULE_CODE6                                            = 11, // <code> ::= <do-while>
        RULE_CODE7                                            = 12, // <code> ::= <method>
        RULE_CODE8                                            = 13, // <code> ::= <callmeth>
        RULE_ASS_LPAREN_RPAREN_EQ_COMMA                       = 14, // <ass> ::= <id> '(' <datatype> ')' '=' <expr> ','
        RULE_DATATYPE_INT                                     = 15, // <datatype> ::= int
        RULE_DATATYPE_STRING                                  = 16, // <datatype> ::= string
        RULE_DATATYPE_DOUBLE                                  = 17, // <datatype> ::= double
        RULE_DATATYPE_FLOAT                                   = 18, // <datatype> ::= float
        RULE_EXPR_PLUS                                        = 19, // <expr> ::= <expr> '+' <multi>
        RULE_EXPR_MINUS                                       = 20, // <expr> ::= <expr> '-' <multi>
        RULE_EXPR                                             = 21, // <expr> ::= <multi>
        RULE_MULTI_TIMES                                      = 22, // <multi> ::= <multi> '*' <value>
        RULE_MULTI_DIV                                        = 23, // <multi> ::= <multi> '/' <value>
        RULE_MULTI                                            = 24, // <multi> ::= <value>
        RULE_VALUE_LPAREN_RPAREN                              = 25, // <value> ::= '(' <value> ')'
        RULE_VALUE                                            = 26, // <value> ::= <id>
        RULE_VALUE2                                           = 27, // <value> ::= <digit>
        RULE_VALUE3                                           = 28, // <value> ::= <str>
        RULE_DIGIT_DG                                         = 29, // <digit> ::= dg
        RULE_STR_NUM_ST_NUM                                   = 30, // <str> ::= '#' st '#'
        RULE_IF_IFSTM_LBRACKET_RBRACKET_LT_GT                 = 31, // <if> ::= ifstm '[' <cond> ']' '<' <code> '>'
        RULE_IF_IFSTM_LBRACKET_RBRACKET_LT_GT_ELSE_LT_GT      = 32, // <if> ::= ifstm '[' <cond> ']' '<' <code> '>' else '<' <code> '>'
        RULE_COND                                             = 33, // <cond> ::= <expr> <op> <expr>
        RULE_OP_GT                                            = 34, // <op> ::= '>'
        RULE_OP_LT                                            = 35, // <op> ::= '<'
        RULE_OP_GTEQ                                          = 36, // <op> ::= '>='
        RULE_OP_LTEQ                                          = 37, // <op> ::= '<='
        RULE_OP_EQEQ                                          = 38, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                      = 39, // <op> ::= '!='
        RULE_SWITCH_SWSTM_LBRACKET_RBRACKET                   = 40, // <switch> ::= <ass> swstm <expr> '[' <case-list> ']'
        RULE_CASELIST_CASE1_BREAK                             = 41, // <case-list> ::= 'case1' <expr> break <case-list>
        RULE_CASELIST_CASE2_BREAK                             = 42, // <case-list> ::= 'case2' <expr> break <case-list>
        RULE_CASELIST_CASE3_BREAK                             = 43, // <case-list> ::= 'case3' <expr> break <case-list>
        RULE_CASELIST_DEFAULT                                 = 44, // <case-list> ::= default <expr>
        RULE_FOR_FORSTM_LBRACKET_DOT_DOT_RBRACKET_LT_GT       = 45, // <for> ::= forstm '[' <ass> '.' <cond> '.' <incr> ']' '<' <code> '>'
        RULE_INCR_PLUSPLUS                                    = 46, // <incr> ::= <id> '++'
        RULE_INCR_MINUSMINUS                                  = 47, // <incr> ::= <id> '--'
        RULE_INCR_PLUSPLUS2                                   = 48, // <incr> ::= '++' <id>
        RULE_INCR_MINUSMINUS2                                 = 49, // <incr> ::= '--' <id>
        RULE_INCR                                             = 50, // <incr> ::= <ass>
        RULE_WHILE_WHILE_LBRACKET_DOT_RBRACKET_LT_GT          = 51, // <while> ::= <ass> while '[' <cond> '.' <incr> ']' '<' <code> '>'
        RULE_DOWHILE_DO_LBRACKET_DOT_DOT_RBRACKET_WHILE_LT_GT = 52, // <do-while> ::= do '[' <ass> '.' <cond> '.' <incr> ']' while '<' <code> '>'
        RULE_METHOD_LBRACKET_RBRACKET_LT_GT                   = 53, // <method> ::= <id> '[' <arg> ']' '<' <code> '>'
        RULE_ARG_COMMA                                        = 54, // <arg> ::= <expr> ',' <expr>
        RULE_CALLMETH_LBRACKET_RBRACKET                       = 55  // <callmeth> ::= <id> '[' <arg> ']'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;

        public MyParser(string filename, ListBox lst, ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open,
                                               FileAccess.Read,
                                               FileShare.Read);
            this.lst = lst;
            this.ls = ls;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUM :
                //'#'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOLLAR :
                //'$'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE1 :
                //'case1'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE2 :
                //'case2'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE3 :
                //'case3'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DG :
                //dg
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORSTM :
                //forstm
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOODBYE :
                //goodbye
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //ID
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTM :
                //ifstm
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ST :
                //st
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWSTM :
                //swstm
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WELCOME :
                //welcome
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARG :
                //<arg>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASS :
                //<ass>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALLMETH :
                //<callmeth>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASEMINUSLIST :
                //<case-list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CODE :
                //<code>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //<comment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATATYPE :
                //<datatype>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOMINUSWHILE :
                //<do-while>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //<for>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //<if>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCR :
                //<incr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD :
                //<method>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTI :
                //<multi>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEQUENCE :
                //<sequence>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SOURCECODE :
                //<sourcecode>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STR :
                //<str>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //<switch>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE2 :
                //<while>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_SEQUENCE_WELCOME_GOODBYE :
                //<sequence> ::= welcome <sourcecode> goodbye
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SOURCECODE :
                //<sourcecode> ::= <comment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SOURCECODE2 :
                //<sourcecode> ::= <code>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SOURCECODE3 :
                //<sourcecode> ::= <comment> <code> <sourcecode>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMMENT_DOLLAR :
                //<comment> ::= '$' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= ID
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE :
                //<code> ::= <ass>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE2 :
                //<code> ::= <switch>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE3 :
                //<code> ::= <if>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE4 :
                //<code> ::= <for>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE5 :
                //<code> ::= <while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE6 :
                //<code> ::= <do-while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE7 :
                //<code> ::= <method>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CODE8 :
                //<code> ::= <callmeth>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASS_LPAREN_RPAREN_EQ_COMMA :
                //<ass> ::= <id> '(' <datatype> ')' '=' <expr> ','
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_INT :
                //<datatype> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_STRING :
                //<datatype> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_DOUBLE :
                //<datatype> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATATYPE_FLOAT :
                //<datatype> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <multi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <multi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <multi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTI_TIMES :
                //<multi> ::= <multi> '*' <value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTI_DIV :
                //<multi> ::= <multi> '/' <value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTI :
                //<multi> ::= <value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<value> ::= '(' <value> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<value> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE2 :
                //<value> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE3 :
                //<value> ::= <str>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DG :
                //<digit> ::= dg
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STR_NUM_ST_NUM :
                //<str> ::= '#' st '#'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IFSTM_LBRACKET_RBRACKET_LT_GT :
                //<if> ::= ifstm '[' <cond> ']' '<' <code> '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_IFSTM_LBRACKET_RBRACKET_LT_GT_ELSE_LT_GT :
                //<if> ::= ifstm '[' <cond> ']' '<' <code> '>' else '<' <code> '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_SWSTM_LBRACKET_RBRACKET :
                //<switch> ::= <ass> swstm <expr> '[' <case-list> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE1_BREAK :
                //<case-list> ::= 'case1' <expr> break <case-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE2_BREAK :
                //<case-list> ::= 'case2' <expr> break <case-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE3_BREAK :
                //<case-list> ::= 'case3' <expr> break <case-list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_DEFAULT :
                //<case-list> ::= default <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_FORSTM_LBRACKET_DOT_DOT_RBRACKET_LT_GT :
                //<for> ::= forstm '[' <ass> '.' <cond> '.' <incr> ']' '<' <code> '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCR_PLUSPLUS :
                //<incr> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCR_MINUSMINUS :
                //<incr> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCR_PLUSPLUS2 :
                //<incr> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCR_MINUSMINUS2 :
                //<incr> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCR :
                //<incr> ::= <ass>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_WHILE_LBRACKET_DOT_RBRACKET_LT_GT :
                //<while> ::= <ass> while '[' <cond> '.' <incr> ']' '<' <code> '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOWHILE_DO_LBRACKET_DOT_DOT_RBRACKET_WHILE_LT_GT :
                //<do-while> ::= do '[' <ass> '.' <cond> '.' <incr> ']' while '<' <code> '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_LBRACKET_RBRACKET_LT_GT :
                //<method> ::= <id> '[' <arg> ']' '<' <code> '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARG_COMMA :
                //<arg> ::= <expr> ',' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CALLMETH_LBRACKET_RBRACKET :
                //<callmeth> ::= <id> '[' <arg> ']'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }


        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + " In Line: " + args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "Expected Token: " + args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }
        private void TokenReadEvent(LALRParser pr, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "  \t \t " + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);
        }

    }
}
