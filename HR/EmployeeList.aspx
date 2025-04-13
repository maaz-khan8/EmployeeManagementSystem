<%@ Page Title="View Employees" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="EmployeeManagementSystem.HR.EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Employee List</h2>
        
        <div class="row mb-3">
            <div class="col-md-6">
                <div class="input-group">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by name or department"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>

        <asp:GridView ID="gvEmployees" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="false"
            DataKeyNames="EmployeeID" OnRowCommand="gvEmployees_RowCommand">
            <Columns>
                <asp:BoundField DataField="EmployeeID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
                <asp:BoundField DataField="Designation" HeaderText="Designation" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" DataFormatString="{0:C}" />
                <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditEmployee" CommandArgument='<%# Eval("EmployeeID") %>'
                            CssClass="btn btn-sm btn-primary">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="alert alert-info">No employees found.</div>
            </EmptyDataTemplate>
        </asp:GridView>

        <asp:Panel ID="pnlEmployeeForm" runat="server" Visible="false">
            <div class="card">
                <div class="card-header">
                    <h5><asp:Literal ID="litFormTitle" runat="server"></asp:Literal></h5>
                </div>
                <div class="card-body">
                    <asp:HiddenField ID="hdnEmployeeID" runat="server" />
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblName" runat="server" CssClass="form-label" Text="Name"></asp:Label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblEmail" runat="server" CssClass="form-label" Text="Email"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required="required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblDepartment" runat="server" CssClass="form-label" Text="Department"></asp:Label>
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-select">
                                <asp:ListItem Text="-- Select Department --" Value="" />
                                <asp:ListItem Text="IT" Value="IT" />
                                <asp:ListItem Text="HR" Value="HR" />
                                <asp:ListItem Text="Finance" Value="Finance" />
                                <asp:ListItem Text="Marketing" Value="Marketing" />
                                <asp:ListItem Text="Operations" Value="Operations" />
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblDesignation" runat="server" CssClass="form-label" Text="Designation"></asp:Label>
                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <asp:Label ID="lblSalary" runat="server" CssClass="form-label" Text="Salary"></asp:Label>
                            <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control" TextMode="Number" required="required"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblJoiningDate" runat="server" CssClass="form-label" Text="Joining Date"></asp:Label>
                            <asp:TextBox ID="txtJoiningDate" runat="server" CssClass="form-control" TextMode="Date" required="required"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary ms-2" OnClick="btnCancel_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
