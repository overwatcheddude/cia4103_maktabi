<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="BookDetails.aspx.cs" Inherits="BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 20px;
        }
        .auto-style2 {
            width: 101px;
            height: 104px;
        }
        .auto-style4 {
            height: 104px;
        }
        .auto-style5 {
            width: 81px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h1>Book Details</h1>
    <asp:DataList ID="dlBooks" runat="server" Width="100%">
        <ItemTemplate>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3" colspan="2"><span class="booktitle">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Title") %>'></asp:Literal>
                        </span></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# "images/"+Eval("coverphoto") %>' Width="90px" />
                    </td>
                    <td class="auto-style4"><strong>Author:</strong>
                        <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Author") %>'></asp:Literal>
                        <br />
                        <strong>Year:</strong>
                        <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("Year") %>'></asp:Literal>
                        <br />
                        <ajaxToolkit:Rating ID="Rating1" runat="server" ReadOnly="True" FilledStarCssClass="filled" EmptyStarCssClass="empty" StarCssClass="filled" WaitingStarCssClass="filled" BehaviorID="Rating1_RatingExtender" CurrentRating='<%# Eval("avgRating") %>'>
                        </ajaxToolkit:Rating>
                         Votes (<asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Votes") %>'></asp:Literal>)<br />
                        <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <h1>User Reviews</h1>
    <asp:DataList ID="dlReviews" runat="server">
        <ItemTemplate>
            <table class="auto-style1">
                <tr>
                    <%--TODO: Create star rating --%>
                    <td>
                    <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("Rating") %>'></asp:Literal>
                    <%--<ajaxToolkit:Rating ID="Rating2" runat="server" ReadOnly="True" FilledStarCssClass="filled" EmptyStarCssClass="empty" StarCssClass="filled" WaitingStarCssClass="filled" BehaviorID="Rating2_RatingExtender" CurrentRating='<%# Eval("Rating") %>'></ajaxToolkit:Rating></td>--%>
                    </td>
                    <td><asp:Literal ID="Literal8" runat="server" Text='<%# Eval("Username") %>'></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Literal ID="Literal9" runat="server" Text='<%# Eval("Comment") %>'></asp:Literal></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>