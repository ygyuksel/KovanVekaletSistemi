<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VekaletAtama.aspx.cs" Inherits="KovanVekaletSistemWeb.VekaletAtama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<style>
	 .myLabel{
		 position:absolute;
	 }
	</style>
    <!-- start: page -->
					<div class="row">
						<div class="col-xs-12">
							<section class="panel">
								<header class="panel-heading">

									<h2 class="panel-title">Vekalet İşlemleri</h2>
								</header>
								<div class="panel-body">
									<form class="form-horizontal form-bordered" action="#" runat="server">
										<div class="form-group">
											<label class="col-md-3 control-label">Vekalet Veren Kişi</label>
											<div class="col-md-6">
												
												<span ID="lblUserName" runat="server" style="position:absolute; margin-top: 7px;" >Yasin</span>
											</div>
										</div>
										<div class="form-group">
											<label class="col-md-3 control-label">Atanan Kişi</label>
											<div class="col-md-6">
												<asp:DropDownList ID="ddlUsers" runat="server" class="form-control populate"></asp:DropDownList>
												
											</div>
										</div>
										<div class="form-group">
											<label class="col-md-3 control-label">Vekalet Tarihi</label>
											<div class="col-md-6">
												<div class="input-daterange input-group" data-plugin-datepicker>
													<span class="input-group-addon">
														<i class="fa fa-calendar"></i>
													</span>
													<input type="text" class="form-control" name="start">
													<span class="input-group-addon">to</span>
													<input type="text" class="form-control" name="end">
												</div>
											</div>
										</div>
										<div class="form-group">
											<label class="col-md-3 control-label" for="inputDefault">Text</label>
											<div class="col-md-6">
												<input type="text" class="form-control" id="inputDefault">
											</div>
										</div>
									</form>
								</div>
							</section>
						</div>
					</div>
					<!-- end: page -->
</asp:Content>
