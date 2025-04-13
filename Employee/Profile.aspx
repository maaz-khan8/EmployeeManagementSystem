<%@ Page Title="My Profile" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EmployeeManagementSystem.Employee.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>My Profile</h2>
        
        <div class="row mt-4">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-header">
                        <h5>Employee Information</h5>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <strong>Employee ID:</strong>
                            </div>
                            <div class="col-md-8">
                                <asp:Literal ID="litEmployeeID" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <strong>Name:</strong>
                            </div>
                            <div class="col-md-8">
                                <asp:Literal ID="litName" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <strong>Email:</strong>
                            </div>
                            <div class="col-md-8">
                                <asp:Literal ID="litEmail" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <strong>Department:</strong>
                            </div>
                            <div class="col-md-8">
                                <asp:Literal ID="litDepartment" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <strong>Designation:</strong>
                            </div>
                            <div class="col-md-8">
                                <asp:Literal ID="litDesignation" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <strong>Joining Date:</strong>
                            </div>
                            <div class="col-md-8">
                                <asp:Literal ID="litJoiningDate" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#changePasswordModal">
                            Change Password
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Change Password Modal -->
    <div class="modal fade" id="changePasswordModal" tabindex="-1" aria-labelledby="changePasswordModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="changePasswordModalLabel">Change Password</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="mb-3">
                        <asp:Label ID="lblCurrentPassword" runat="server" CssClass="form-label" Text="Current Password"></asp:Label>
                        <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control" TextMode="Password" required="required"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblNewPassword" runat="server" CssClass="form-label" Text="New Password"></asp:Label>
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" required="required"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <asp:Label ID="lblConfirmPassword" runat="server" CssClass="form-label" Text="Confirm New Password"></asp:Label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" required="required"></asp:TextBox>
                        <asp:CompareValidator ID="cvPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewPassword"
                            ErrorMessage="Passwords do not match" CssClass="text-danger" Display="Dynamic"></asp:CompareValidator>
                    </div>
                    <asp:Label ID="lblPasswordMessage" runat="server" CssClass="text-danger"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="btn btn-primary" OnClick="btnChangePassword_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
