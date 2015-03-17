<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="hw1login.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet/StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
   
     <div id="header">
        &nbsp;<div id="banner">

            <marquee id="mar" onmouseover="mar.stop()" onmouseout="mar.start()" direction="up" scrollamount="2">
                <h1>Welcome to Siyang Wang`s Web Site</h1></marquee>

        </div>

    </div>

    <div id="leftnavbar" style="line-height:1.3em">

              <form id="form1" runat="server">

            <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click"/>
            </form>  
    
        <ul>

            
           
            
            <li>               
                    <a href="http://www.yahoo.com">Yahoo!</a>                
            </li>
            <li>
                    <a href="http://wwww.google.com">Google</a>
            </li>
            <li>
                    <a href="http://wwww.facebook.com">Facebook</a>
            </li>
            <li>
                    <a href="http://wwww.twitter.com">twitter</a>
            </li>
            <li>
                    <a href="http://wwww.nyu.edu">NYU</a>
            </li>
            <li>
                    <a href="http://cs.nyu.edu">NYU CS</a>
            </li>
            <li>
                    <a href="http://wwww.msn.com">MSN</a>
            </li>
            <li>
                    <a href="http://wwww.lycos.com">LYCOS</a>
            </li>
            <li>
                    <a href="http://wwww.comcast.net">Comcast</a>
            </li>
        </ul>
    </div>

    <div id="content">
        <h2>NYU from Wikipedia</h2>
        
        <p class="cont">
            <a href="http://wwww.nyu.edu">New York University (NYU)</a> is a private, nonsectarian American research university based in <a href="http://www1.nyc.gov/">New York City</a>.
            NYU's main campus is located at <a href="http://en.wikipedia.org/wiki/Greenwich_Village">Greenwi in Lower Manhattan. Founded in 1831, NYU is one of the
            largest private nonprofit institutions of American higher education.
        </p>

        &nbsp;<p class="cont">
            NYU was elected to the Association of American Universities in 1950. NYU counts 36 NYU counts 36 <a href="http://wwww.nobelprize.org"> nobel prize </a>winners,
   three <a href="http://wwww.abelprize.no"> abel prize </a>winners, 10 national medal of science recipients, 16 <a href="http://wwww.pulitzer.org"> pulitzer prize </a> winners,
    over 30 academy award winne four putnam competition winners, russ prize, gordon prize, and draper prize
    winners, turing award winners, and emmy, grammy, and tony award winners among its faculty and alumni.
    nyu also has macarthur and guggenheim fellowship holders as well as national academy of sciences and
    national academy of engineering members among its past and present graduates and faculty.
</p>
        <p class="cont">
            NYU is organized into more than 20 schools, colleges, and institutes, located in six centers throughout
            Manhattan and Downtown Brooklyn, as well as more than a dozen other sites across the world, with plans for
            further expansion. According to the Institute of International Education, NYU sends more
            students to study abroad than any other US college or university, and the College Board reports
            more online searches by international students for "NYU" than for any other university.(from Wikipedia)
        </p>
        
    </div>
    <div id="fade">
        <h3>Hahaha~You`ve got my hidden paragraph!!! Thank you for visiting!!!</h3>
    </div>
</body>
</html>
