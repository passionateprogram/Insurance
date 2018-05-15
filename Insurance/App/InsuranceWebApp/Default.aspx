<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InsuranceWebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insurance Web App</title>
   <link rel="stylesheet" type="text/css" href="style/style.css" title="style" />
</head>
<body>
     <div id="main">
    <div id="header">
      <div id="logo">
        <div !-- class="logo_colour", allows you to change the colour of the text -->
          <h1>Smart Auto<span class="logo_colour"> Insurance </span></h1>
          <h2 style="font-size:16px">Simple and Automatic</h2>
        </div>
      </div>
      <div id="menubar">
          <div >
          <!-- class="logo_colour", allows you to change the colour of the text -->
          <h1 style="color:white; margin-left:20px"> Get a Quick, Personalized Insurance Quote Today. </h1>
          
        </div>
        
      </div>
    </div>
    <div id="site_content">
      <div class="sidebar">
     <form id="form1" runat="server">         
        <div style="margin-top:20px; margin-left:30px">
            <iframe  src='https://webchat.botframework.com/embed/InsureAgent?s=XIol8AVfYCg.cwA.XLQ.Kcr8k1MeeeYATvNrAiuWPPC49LmSSF6uIawIU8bpo8s' height="500"></iframe>
        </div>
    </form>
      </div>
      <div id="content">
        <!-- insert the page content here -->
        <h1>Welcome to the Auto insurance</h1>
        <p>A policy with Smart Auto Insurance is more than just an insurance. It's personalized help from new technology, innovative tools — like BOT — that help keep you driving forward and quality coverage paired with great savings</p>
        <div>
            <marquee >
                <img src="style/Telematics-Driving-Usage-Based-Auto-Insurance.png"  alt="Natural" />
            </marquee>
             
               <%-- <div>
                    <div style="float:left">
                        
                    </div>
                    <div  style="float:left"></div>
                </div>
    --%>
  

        </div>
      </div>
    </div>
    <div id="footer">
      
    </div>
  </div>
    
</body>
</html>
