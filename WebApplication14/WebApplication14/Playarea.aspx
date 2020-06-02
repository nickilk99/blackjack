<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Playarea.aspx.cs" Inherits="WebApplication14.Playarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            font-weight: 700;
        }
        #dealerArea {
            width: 677px;
            margin-left: 4px;
        }
        #playerArea {
            width: 676px;
            margin-left: 6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div style="margin-left: 166px">


                            <div id="dealerArea">

 
                                <br />
            <p style="height: 76px">
                <br />
                <asp:Label ID="lblDealerTotal" runat="server" Text="Label">Dealer Total: </asp:Label>
                <asp:TextBox ID="txtDealerScore" runat="server" Width="27px" Height="16px" Enabled="False" style="margin-left: 15px"></asp:TextBox>
            </p>
                                                <div>
                <asp:Panel ID="Panel2" runat="server" Height="85px" style="margin-top: 33px">


                </asp:Panel>
                </div>
            </div>

                <div id="playerArea">
                                    <div>
                <asp:Panel ID="Panel1" runat="server" Height="93px" style="margin-top: 43px; margin-bottom: 33px">
                </asp:Panel>
                </div>
                    <asp:Label ID="Label1" runat="server" Text="Player Total: "></asp:Label>
                    <asp:TextBox ID="txtPlayerScore" runat="server" Width="28px" Enabled="False" style="margin-left: 13px"></asp:TextBox>
                                    <br />
                                    Money:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblPMoney" runat="server"></asp:Label>
                                    <br />
                                    Bet:<asp:TextBox ID="txtBet" runat="server" style="margin-left: 71px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBet" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtBet" ErrorMessage="Must be between 1 and 100" ForeColor="Red" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                    <br />
                                    <br />
                </div>
            <asp:Button ID="btnHit" runat="server" OnClick="Hit" Text="Hit" style="margin-left: 0px" />
            <asp:Button ID="btnPass" runat="server" OnClick="Pass" Text="Stand" style="margin-left: 5px" />
            <br />
            <br />

            <br />
            <asp:Button ID="btnRestart" runat="server" OnClick="Restart" Text="Restart" style="margin-left: 0px" />
            <asp:Button ID="btnDeal" runat="server" OnClick="DealCards" Text="Deal" style="margin-left: 3px" />
                            <br />
                            <br />
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>


        <p>
            &nbsp;</p>
    </form>

</body>
</html>
