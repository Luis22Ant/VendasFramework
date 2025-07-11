<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrega.aspx.cs" Inherits="Vendas.View.Entrega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/all.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/all.min.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/brands.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/brands.min.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/fontawesome.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/fontawesome.min.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/regular.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/regular.min.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/solid.css" />
    <link rel="stylesheet" type="text/css" href="../fontawesome/css/solid.min.css" />
    <script src="https://kit.fontawesome.com/ba7dac9af2.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://kit.fontawesome.com/ba7dac9af2.css" crossorigin="anonymous" />



    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../CSS/gridview.css" type="text/css" rel="stylesheet" />
    <link href="../Resources/bootstrap.min.css" rel="stylesheet" />
    <script src="../Resources/bootstrap.min.js"></script>
    <title>Entregas</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
                </asp:ScriptManager>

                <asp:HiddenField runat="server" ID="hddAcao" />
                <asp:HiddenField runat="server" ID="hddId" />
                <section id="NavBarSection" runat="server">


                    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                        <div class="container-fluid">
                            <a class="navbar-brand" href="#">Entregas</a>
                            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                                aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                                <span class="navbar-toggler-icon"></span>
                            </button>

                            <div class="collapse navbar-collapse" id="navbarNav">
                                <ul class="navbar-nav ms-auto">
                                    <li class="nav-item">
                                        <a class="nav-link active" aria-current="page" href="#">Início</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#">Produtos</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#">Clientes</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#">Relatórios</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="#">Contato</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </nav>

                </section>
                <section id="FilterSection" runat="server">
                    <div class="container mt-3 mb-3">
                        <div class="row g-3">
                            <div class="col-md-3">
                                <asp:TextBox ID="txtNumeroPedido" runat="server" CssClass="form-control" placeholder="Número do pedido" />
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtDataDe" runat="server" CssClass="form-control" TextMode="Date" />
                            </div>

                            <div class="col-md-3">
                                <asp:TextBox ID="txtDataAte" runat="server" CssClass="form-control" TextMode="Date" />
                            </div>

                            <div class="col-md-3">
                                <asp:Button ID="btnFiltrar" OnClick="btnFiltrar_Click" runat="server" Text="Filtrar" CssClass="btn btn-primary mt-2" />
                            </div>

                        </div>
                    </div>
                    <div class="row m-3">
                        <div class="col-md-1">
                            <asp:LinkButton ID="LbtnIncluir" class="btn btn-success" OnClick="LbtnIncluir_Click" runat="server">
            Incluir <i class="fas fa-user-plus"></i>
                            </asp:LinkButton>
                        </div>
                    </div>

                </section>



                <section>


                    <asp:MultiView ID="MultiViewEntrega" runat="server">
                        <!--VIEW PRINCIPAL-->
                        <asp:View runat="server">
                            <div class="divGdv">
                                <asp:GridView ID="GdvEntrega" CssClass="table gridview-layout" BorderWidth="1px" AutoGenerateColumns="true" runat="server"
                                    OnPageIndexChanging="GdvEntrega_PageIndexChanging" OnRowDataBound="GdvEntrega_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <div class="caixa-icone">
                                                    <a id="btnVisualizar" runat="server" title="Visualizar" onserverclick="btnVisualizar_ServerClick">
                                                        <i class="rowTable fa-solid fa-eye grid-icone grid-icone-dark"></i>
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <div class="caixa-icone">
                                                    <a id="btnEditar" runat="server" title="Editar" onserverclick="btnEditar_ServerClick">
                                                        <i class="rowTable fa-solid fa-pencil grid-icone grid-icone-dark"></i>
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="30px">
                                            <ItemTemplate>
                                                <div class="caixa-icone">
                                                    <a id="btnExcluir" runat="server" title="Excluir" onserverclick="btnExcluir_ServerClick">
                                                        <i class="rowTable fa-solid fa-trash grid-icone grid-icone-dark"></i>
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="rowTable cabecalho-grid item-padding" VerticalAlign="Middle" Wrap="False" />
                                    <RowStyle CssClass="rowTable linha-grid table-item item-padding" Wrap="False" />
                                    <AlternatingRowStyle CssClass="rowTable linha-grid linha-grid-alternada" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000000" CssClass="GridPager" HorizontalAlign="Left" />
                                    <PagerSettings Position="Bottom" Mode="NumericFirstLast"
                                        FirstPageText="<i class='GridPager fas fa-angle-double-left'></i>"
                                        LastPageText="<i class='GridPager fas fa-angle-double-right'></i>" />
                                </asp:GridView>
                            </div>
                        </asp:View>
                        <asp:View runat="server">
                            <div class="container mt-5 mb-5">
                                <h2>Cadastro de Entrega</h2>
                                <div class="row g-3">

                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="txtNumPedido" Text="Número do pedido" CssClass="form-label" />
                                        <asp:TextBox ID="txtNumPedido" runat="server" CssClass="form-control" />
                                    </div>

                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="txtValorEntrega" Text="Valor da entrega" CssClass="form-label" />
                                        <asp:TextBox ID="txtValorEntrega" runat="server" CssClass="form-control" />
                                    </div>

                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="txtDataPrevisao" TextMode="Date" Text="Previsão de entrega" CssClass="form-label" />
                                        <asp:TextBox ID="txtDataPrevisao" runat="server" TextMode="Date" CssClass="form-control" />
                                    </div>

                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="ddlCliente" Text="Cliente" CssClass="form-label" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCliente">
                                            <asp:ListItem Value="123" Text="Teste"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="txtEndereco" Text="Endereço" CssClass="form-label" />
                                        <asp:TextBox ID="txtEndereco" runat="server" CssClass="form-control" />
                                    </div>

                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="ddlFormPag" Text="Forma de pagamento" CssClass="form-label" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlFormPag">
                                            <asp:ListItem Value="123" Text="Teste"></asp:ListItem>
                                            <asp:ListItem Value="1234" Text="Teste2"></asp:ListItem>
                                            <asp:ListItem Value="1235" Text="Teste3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="ddlStatus" Text="Status" CssClass="form-label" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlStatus">
                                            <asp:ListItem Value="123" Text="Teste"></asp:ListItem>
                                            <asp:ListItem Value="1234" Text="Teste2"></asp:ListItem>
                                            <asp:ListItem Value="1235" Text="Teste3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="txtTelefone" Text="Telefone" CssClass="form-label" />
                                        <asp:TextBox ID="txtTelefone" runat="server" TextMode="Phone" CssClass="form-control" />
                                    </div>

                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="ddlCaminhao" Text="Caminhão" CssClass="form-label" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCaminhao">
                                            <asp:ListItem Value="123" Text="Teste"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="txtNumParcial" Text="Num Parcial" CssClass="form-label" />
                                        <asp:TextBox ID="txtNumParcial" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label runat="server" AssociatedControlID="txtObservacao" Text="Observação" CssClass="form-label" />
                                        <asp:TextBox ID="txtObservacao" runat="server" CssClass="form-control" />
                                    </div>

                                    <div class="col-12 text-end mt-3">
                                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-danger" OnClick="btnVoltar_Click" />
                                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-success" OnClick="btnConfirmar_Click" />
                                    </div>
                                </div>
                            </div>
                        </asp:View>
                    </asp:MultiView>
                </section>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
