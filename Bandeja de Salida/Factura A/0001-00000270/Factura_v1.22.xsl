<?xml version="1.0" encoding="ISO-8859-1"?>
<!--
DWXMLSource="surveys.xml" -->
<!DOCTYPE xsl:stylesheet  [
        <!ENTITY nbsp   "&#160;">
	<!ENTITY ordm   "&#186;">
	<!ENTITY quot   "&#034;">
	<!ENTITY aacute  "&#180;">
	<!ENTITY eacute  "&#233;">
	<!ENTITY iacute  "&#237;">
	<!ENTITY oacute  "&#243;">
	<!ENTITY uacute  "&#250;">
	<!ENTITY ntilde  "&#241;">
	<!ENTITY Aacute  "&#193;">
	<!ENTITY Eacute  "&#201;">
	<!ENTITY Iacute  "&#205;">
	<!ENTITY Oacute  "&#211;">
	<!ENTITY Uacute  "&#218;">
	<!ENTITY Ntilde  "&#209;">
]>
<xsl:stylesheet version="1.0" 
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:output method="html" encoding="UTF-8" doctype-public="-//W3C//DTD 
XHTML 1.0 Transitional//EN" 
doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-
transitional.dtd"/>

<xsl:decimal-format name="european" decimal-separator=',' grouping-separator='.' />
<xsl:template match="/">
<xsl:param name="number"><xsl:value-of select="comprobante/resumen/importe_total_factura"/></xsl:param>
<xsl:param name="tipodoc"><xsl:value-of select="format-number(comprobante/cabecera/informacion_comprador/codigo_doc_identificatorio,'00','european')"/></xsl:param>
<xsl:param name="tpofactura"><xsl:value-of select="format-number(comprobante/cabecera/informacion_comprobante/tipo_de_comprobante,'00','european')"/></xsl:param>
<xsl:param name="condicivac"><xsl:value-of select="format-number(comprobante/cabecera/informacion_comprador/condicion_IVA,'00','european')"/></xsl:param>
<xsl:param name="condicivav"><xsl:value-of select="format-number(comprobante/cabecera/informacion_vendedor/condicion_IVA,'00','european')"/></xsl:param>
<xsl:param name="codmon"><xsl:value-of select="comprobante/resumen/codigo_moneda"/></xsl:param>
<xsl:param name="codjuris"><xsl:value-of select="format-number(comprobante/resumen/impuestos/codigo_jurisdiccion,'00','european')"/></xsl:param>
<xsl:param name="codprovv"><xsl:value-of select="format-number(comprobante/cabecera/informacion_vendedor/provincia,'00','european')"/></xsl:param>
<xsl:param name="codprovc"><xsl:value-of select="format-number(comprobante/cabecera/informacion_comprador/provincia,'00','european')"/></xsl:param>

<html xmlns:xs="http://www.w3.org/2001/XMLSchema">

<head>
<SCRIPT LANGUAGE='javascript' SRC='./code2of5.js'></SCRIPT>
<script>
var MAX_ALTO_INFO_DESEESTR = 120;

var linksValidos = "";
var htmldiv_MKT_header = '<xsl:value-of select="comprobante/extensiones/extensiones_datos_marketing/cabecera"/>';
var htmldiv_MKT_pie = '<xsl:value-of select="comprobante/extensiones/extensiones_datos_marketing/pie"/>';
<xsl:text disable-output-escaping="yes"><![CDATA[

var BrowserDetect = {
	init: function () {
		this.browser = this.searchString(this.dataBrowser) || "An unknown browser";
		this.version = this.searchVersion(navigator.userAgent)
			|| this.searchVersion(navigator.appVersion)
			|| "an unknown version";
		this.OS = this.searchString(this.dataOS) || "an unknown OS";
	},
	searchString: function (data) {
		for (var i=0;i<data.length;i++)	{
			var dataString = data[i].string;
			var dataProp = data[i].prop;
			this.versionSearchString = data[i].versionSearch || data[i].identity;
			if (dataString) {
				if (dataString.indexOf(data[i].subString) != -1)
					return data[i].identity;
			}
			else if (dataProp)
				return data[i].identity;
		}
	},
	searchVersion: function (dataString) {
		var index = dataString.indexOf(this.versionSearchString);
		if (index == -1) return;
		return parseFloat(dataString.substring(index+this.versionSearchString.length+1));
	},
	dataBrowser: [
		{ 	string: navigator.userAgent,
			subString: "OmniWeb",
			versionSearch: "OmniWeb/",
			identity: "OmniWeb"
		},
		{
			string: navigator.vendor,
			subString: "Apple",
			identity: "Safari"
		},
		{
			prop: window.opera,
			identity: "Opera"
		},
		{
			string: navigator.vendor,
			subString: "iCab",
			identity: "iCab"
		},
		{
			string: navigator.vendor,
			subString: "KDE",
			identity: "Konqueror"
		},
		{
			string: navigator.userAgent,
			subString: "Firefox",
			identity: "Firefox"
		},
		{
			string: navigator.vendor,
			subString: "Camino",
			identity: "Camino"
		},
		{		// for newer Netscapes (6+)
			string: navigator.userAgent,
			subString: "Netscape",
			identity: "Netscape"
		},
		{
			string: navigator.userAgent,
			subString: "MSIE",
			identity: "Explorer",
			versionSearch: "MSIE"
		},
		{
			string: navigator.userAgent,
			subString: "Gecko",
			identity: "Mozilla",
			versionSearch: "rv"
		},
		{ 		// for older Netscapes (4-)
			string: navigator.userAgent,
			subString: "Mozilla",
			identity: "Netscape",
			versionSearch: "Mozilla"
		}
	],
	dataOS : [
		{
			string: navigator.platform,
			subString: "Win",
			identity: "Windows"
		},
		{
			string: navigator.platform,
			subString: "Mac",
			identity: "Mac"
		},
		{
			string: navigator.platform,
			subString: "Linux",
			identity: "Linux"
		}
	]

};
BrowserDetect.init();

function removeNode(n){
   
   try {
	if(n.hasChildNodes()) {
		for(var i=0;i<n.childNodes.length;i++) {
	            n.parentNode.insertBefore(n.childNodes[i].cloneNode(true),n);
	}
    }
    n.parentNode.removeChild(n);
   } 	catch (e) {
   	}
}

function eliminarEventos(node) {
	if (node != null) {
		if (node.onclick != null) {
			try { node.attributes["onabort"].value = ""; } catch (e) {}
			try { node.attributes["onblur"].value = ""; } catch (e) {}
			try { node.attributes["onchange"].value = ""; } catch (e) {}
			try { node.attributes["onclick"].value = ""; } catch (e) {}
			try { node.attributes["ondblClick"].value = ""; } catch (e) {}
			try { node.attributes["ondragDrop"].value = ""; } catch (e) {}
			try { node.attributes["onerror"].value = ""; } catch (e) {}
			try { node.attributes["onfocus"].value = ""; } catch (e) {}
			try { node.attributes["onkeyDown"].value = ""; } catch (e) {}
			try { node.attributes["onkeyPress"].value = ""; } catch (e) {}
			try { node.attributes["onkeyUp"].value = ""; } catch (e) {}
			try { node.attributes["onload"].value = ""; } catch (e) {}
			try { node.attributes["onmouseDown"].value = ""; } catch (e) {}
			try { node.attributes["onmouseMove"].value = ""; } catch (e) {}
			try { node.attributes["onmouseOut"].value = ""; } catch (e) {}
			try { node.attributes["onmouseOver"].value = ""; } catch (e) {}
			try { node.attributes["onmouseUp"].value = ""; } catch (e) {}
			try { node.attributes["onmove"].value = ""; } catch (e) {}
			try { node.attributes["onreset"].value = ""; } catch (e) {}
			try { node.attributes["onresize"].value = ""; } catch (e) {}
			try { node.attributes["onselect"].value = ""; } catch (e) {}
			try { node.attributes["onsubmit"].value = ""; } catch (e) {}
			try { node.attributes["onunload"].value = ""; } catch (e) {}
		}
	}
	if (node.childNodes.length > 0) {
		for (var i=0; i < node.childNodes.length; i++) {			
			eliminarEventos(node.childNodes.item(i));
		}
	}
}

function getMaxChildsHeight(node, height) {	
	if (node.childNodes.length > 0) {
		for (var i=0; i < node.childNodes.length; i++) {			
			height = getMaxChildsHeight(node.childNodes.item(i), height);
		}
	}
	if ((node.tagName != 'BODY') && (node.tagName != 'HTML') && (node.offsetHeight > height)) {
		return node.offsetHeight; 
		
	} else {
		return height;
	}
}

function EliminarScripts(node) {
	var Encontrado = 1;
	while (Encontrado) {
		pos1 = node.innerHTML.toLowerCase().indexOf("<script");
		if (pos1 == -1)
			Encontrado = 0;
		else {
			pos2 = node.innerHTML.toLowerCase().indexOf("</script", pos1);
			if (pos2 == -1)
				Encontrado = 0;
			else {
				node.innerHTML = node.innerHTML.replace(node.innerHTML.substr(pos1, pos2 - pos1 + 9), "");
			}
		}
	}
	Encontrado = 1;
	while (Encontrado) {
		pos1 = node.innerHTML.toLowerCase().indexOf("<form");
		if (pos1 == -1)
			Encontrado = 0;
		else {
			pos2 = node.innerHTML.indexOf(">", pos1);
			if (pos2 == -1)
				Encontrado = 0;
			else {
				node.innerHTML = node.innerHTML.replace(node.innerHTML.substr(pos1, pos2 - pos1 + 1), "");
			}
			node.innerHTML = node.innerHTML.toLowerCase().replace("</form>", "");
		}
	}
}


function ValidarLink(linksValidos, link) {
	resultado = 0;
	var i;
	if (linksValidos.length > 0 && linksValidos[0] == "true") {
		for (i=0; i < linksValidos.length; i++) {
			if (link.match(linksValidos[i]) != null) {
				resultado = 1;
			}
		}
	} else
		resultado = 1
	return resultado;
}

function archivoLinksCargado(id) {

	if (id == 'div_MKT_header') { procesarCamposDesestructurados('div_MKT_header',htmldiv_MKT_header,linksValidos); }
	if (id == 'div_MKT_pie') { procesarCamposDesestructurados('div_MKT_pie',htmldiv_MKT_pie,linksValidos); }

}

function LevantarArchivoLinksValidos(id) {
	
	if (linksValidos == "") {
		var resultado = "";
	
		var xmlhttp=false;
		/*@cc_on @*/
		/*@if (@_jscript_version >= 5)
		// JScript gives us Conditional compilation, we can cope with old IE versions.
		// and security blocked creation of the objects.
		 try {
		  xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
		 } catch (e) {
		  try {
		   xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
		  } catch (E) {
		   xmlhttp = false;
		  }
		 }
		@end @*/
		if (!xmlhttp && typeof XMLHttpRequest!='undefined') {
			try {
				xmlhttp = new XMLHttpRequest();
			} catch (e) {
				xmlhttp=false;
			}
		}
		if (!xmlhttp && window.createRequest) {
			try {
				xmlhttp = window.createRequest();
			} catch (e) {
				xmlhttp=false;
			}
		}
		try {
			xmlhttp.open("GET", "./links.txt",true);
			xmlhttp.onreadystatechange = function() {
				  if (xmlhttp.readyState==4) {			   
				   resultado = xmlhttp.responseText;
	 			   if (resultado != "") {
				 	linksValidos = resultado.split('\r\n');
				 	archivoLinksCargado(id);
				   }
			      }
				  
			 }
			 xmlhttp.send(null);
		} catch (e) {
			archivoLinksCargado(id);
		}
	}	 
	else {
		archivoLinksCargado(id);	
	}

}

function procesarCamposDesestructurados(id, data, linksValidos) {
	var codigoHTML = unescape(data);
	document.getElementById(id).innerHTML = codigoHTML;
	/*
	if (BrowserDetect.browser == 'Explorer') {
		var iframeDocument = document.getElementById(id).contentWindow.document;
		var root = iframeDocument.body;		
		root.innerHTML = codigoHTML;
	} else {
		var frame1=document.getElementById(id);
		var iframeDocument = frame1.contentWindow ? frame1.contentWindow.document : frame1.contentDocument;		
		var root = iframeDocument.documentElement || iframeDocument.body;
		root.innerHTML = codigoHTML;
	}	
	*/
	// ELIMINAMOS EVENTOS
	eliminarEventos(root);

	// ELIMINAMOS SCRIPTS Y FORMS
	EliminarScripts(root);
	
	// LINKS
	var i;
	var elementos = iframeDocument.getElementsByTagName("A");	
	for (i=0;i < elementos.length; i++) {
		elementos[i].target = "_blank";
	   if (!(ValidarLink(linksValidos,elementos[i].href))) {
	   	elementos[i].href = "#";
	   }
	}
	
	// IMAGENES
	var elementos = iframeDocument.getElementsByTagName("IMG");
	for (i=0;i < elementos.length; i++) {
	   if (!ValidarLink(linksValidos,elementos[i].src)) {
	   	removeNode(elementos[i].src);
   	   }
	}
	// ELIMINAMOS IFRAMES
	var elementos = iframeDocument.getElementsByTagName("IFRAME");
	for (i=0;i < elementos.length; i++) {
	  removeNode(elementos[i]);
	}
	// ELIMINAMOS FRAMES
	var elementos = iframeDocument.getElementsByTagName("FRAME");
	for (i=0;i < elementos.length; i++) {
	  removeNode(elementos[i]);
	}

	// por ultimo AJUSTAMOS EL ALTO DEL IFRAME
	/*
	var maxHeight = getMaxChildsHeight(root,0);
	if (maxHeight > MAX_ALTO_INFO_DESEESTR) {
		maxHeight = MAX_ALTO_INFO_DESEESTR;
	}
	document.getElementById(id).height = maxHeight;	
    */
}

function transformarUnidades(id, codigo) {
	var unidades = "1@KILOGRAMO|2@METROS|3@METRO CUADRADO|4@METRO CUBICO|5@LITROS|6@1000 KILOWATT HORA|7@UNIDAD|8@PAR|9@DOCENA|10@QUILATE|11@MILLAR|12@MEGA-U. INT. ACT. ANTIB|13@UNIDAD INT. ACT. INMUNG|14@GRAMO|15@MILIMETRO|16@MILIMETRO CUBICO|17@KILOMETRO|18@HECTOLITRO|19@MEGA U. INT. ACT. INMUNG.|20@CENTÍMETRO|21@KILOGRAMO ACTIVO|22@GRAMO ACTIVO|23@GRAMO BASE|24@UIACTHOR|25@JUEGO O PAQUETE MAZO DE NAIPES|26@MUIACTHOR|27@CENTIMETRO CUBICO|28@UIACTANT|29@TONELADA|30@DECAMETRO CUBICO|31@HECTOMETRO CUBICO|32@KILOMETRO CUBICO|33@MICROGRAMO|34@NANOGRAMO|35@PICOGRAMO|36@MUIACTANT|37@UIACTIG|41@MILIGRAMO|47@MILILITRO|48@CURIE|49@MILICURIE|50@MICROCURIE|51@U. INTER. ACT. HOR.|52@MEGA U. INTER. ACT. HOR.|53@KILOGRAMO BASE|54@GRUESA|55@MUIACTIG|61@KG. BRUTO|62@PACK|63@HORMA|98@OTRAS UNIDADES|99@BONIFICACION";
	MiArray = unidades.split("|");
	document.getElementById(id).innerHTML = codigo;
	for (a=0; a < MiArray.length; a++) {
		separados = MiArray[a].split("@");
		if (codigo == separados[0]) {
			document.getElementById(id).innerHTML = separados[1];
			return 1;
		}
	}
}

]]></xsl:text>

</script>

<style TYPE="text/css">
   /* @import url(http://www.htmlhelp.com/style.css); trata de importar el stylesheet */
body {
	background-color:#ffffff;
	}
.tabla_cabecera {	
	vertical-align: top;
	background-color:#ffffff;
	padding: 0px;
	margin: 0px;
	margin: 5px 0px 5px 5px;
	}
.datos_cabecera {
	vertical-align: top;
	padding: 0px;
	margin: 0px;
	padding: 0px 0px 0px 5px;
	font-size: .63em;
	}
.datos_cabecera tr {
	height: 0px;
	}
</style>

</head>
 <body style="font-family: Arial, Helvetica, sans-serif; margin:0px;">
  
<table border="0" rules="none" width="660" style="height: 900px" cellspacing="0" cellpadding="0" bordercolor="#000000">
  <tr>
    <td valign="top"> 
    <table width="100%" height="100%" border="1" cellspacing="0" cellpadding="0" bordercolor="#000000">
        <tr> 
          <td height="100%" valign="top"> 
		  
			<table width="659" border="0" rules="none" cellspacing="0" cellpadding="0">
			  <tr valign="top">
			    <td width="293">
				  <table  border="0" cellspacing="0" cellpadding="0" bordercolor="#FFFFFF" width="100%" align="center">
				    <tr>
						<td colspan="2" align="center" valign="MIDDLE" style="font-size: 1em;">
						  <xsl:if test="comprobante/extensiones/extensiones_datos_marketing/logo != '' and comprobante/extensiones/extensiones_datos_marketing/url != ''">
							<a href="{comprobante/extensiones/extensiones_datos_marketing/url}" target="_blank"><img style="border-style: none" src="{comprobante/extensiones/extensiones_datos_marketing/logo}" width="80" height="50"/></a><br/>
						  </xsl:if>
						  <xsl:if test="comprobante/extensiones/extensiones_datos_marketing/logo != '' and comprobante/extensiones/extensiones_datos_marketing/url = ''">
							<img src="{comprobante/extensiones/extensiones_datos_marketing/logo}" width="80" height="50"/><br/>
						  </xsl:if>
						  <xsl:value-of select="comprobante/cabecera/informacion_vendedor/razon_social"/>
						</td>
				    </tr>
					<tr valign="bottom">
						<td colspan="2" align="center" valign="MIDDLE"><font size="-3">
						<!-- DOMICILIO VENDEDOR TOTALMENTE VALIDADO -->
						<xsl:if test="comprobante/cabecera/informacion_vendedor/domicilio_calle != ''">
							<xsl:value-of select="comprobante/cabecera/informacion_vendedor/domicilio_calle"/>
						</xsl:if>
						<xsl:if test="comprobante/cabecera/informacion_vendedor/domicilio_numero != ''">
							&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_vendedor/domicilio_numero"/>
						</xsl:if>
						<xsl:if test="comprobante/cabecera/informacion_vendedor/domicilio_piso != ''">
							&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_vendedor/domicilio_piso"/>&ordm;
						</xsl:if>
						<xsl:if test="comprobante/cabecera/informacion_vendedor/domicilio_depto != ''">
							&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_vendedor/domicilio_depto"/>
						</xsl:if>
						<xsl:if test="comprobante/cabecera/informacion_vendedor/domicilio_torre != ''">
							&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_vendedor/domicilio_torre"/>
						</xsl:if>
						<xsl:if test="comprobante/cabecera/informacion_vendedor/domicilio_sector != ''">
							&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_vendedor/domicilio_sector"/>
						</xsl:if>
						<xsl:if test="comprobante/cabecera/informacion_vendedor/domicilio_manzana != ''">
							&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_vendedor/domicilio_manzana"/>
						</xsl:if>
						</font>
						</td>
					</tr>
				    <tr>
					  <td colspan="2" align="center" valign="MIDDLE"><font size="-3"><xsl:value-of select="comprobante/cabecera/informacion_vendedor/cp"/> <xsl:value-of select="comprobante/cabecera/informacion_vendedor/localidad"/>, <xsl:value-of select="comprobante/cabecera/informacion_vendedor/provincia"/></font></td>
					</tr>
					<tr>
						<td colspan="2" align="center" valign="MIDDLE"><font size="-3">GLN: <xsl:value-of select="comprobante/cabecera/informacion_vendedor/GLN"/></font></td>
					</tr>
					<tr>
						<td colspan="2" align="center" valign="MIDDLE"><font size="-3"><xsl:value-of select="comprobante/cabecera/informacion_vendedor/contacto"/>&nbsp;&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_vendedor/email"/><br></br>
			                  Tel <xsl:value-of select="comprobante/cabecera/informacion_vendedor/telefono"/></font>
						</td>
					</tr>
					<tr>
						<td colspan="2" align="center" valign="MIDDLE"><font size="-3">
							<xsl:variable name="ivavdevuelto">
								<xsl:call-template name="condiva"> 
			           				<xsl:with-param name="correspcondiva" select="$condicivav"/> 
			         			</xsl:call-template>
					  		</xsl:variable>
					  		<xsl:choose>
								  <xsl:when test="string-length($ivavdevuelto)!=0">
					  				<xsl:value-of select="$ivavdevuelto"/>
								</xsl:when>
								<xsl:otherwise>
									&nbsp;&nbsp;-&nbsp;&nbsp;
								</xsl:otherwise>
							</xsl:choose> 
							</font>
						</td>
					</tr>
				  </table>
				</td>
				<td height="100%">
				  <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" bordercolor="#000000">
			        <tr> 
			            <td colspan="3" style="border: 2px solid #000000; width:35%" align="center">
			                <font size="5">
							<xsl:variable name="tipofacdevuelto">
							<xsl:call-template name="tipofactu"> 
			           				<xsl:with-param name="corresptipofactu" select="$tpofactura"/> 
			         			</xsl:call-template>
					  		</xsl:variable>
							<xsl:choose>
								<xsl:when test="string-length($tipofacdevuelto)!=0">
					  			  	<xsl:value-of select="$tipofacdevuelto"/>
								</xsl:when>
								<xsl:otherwise>
									&nbsp;&nbsp;-&nbsp;&nbsp;
								</xsl:otherwise>
							</xsl:choose>
					     </font>
						</td>
			        </tr>
					<tr height="40">
						<td width="48%"></td>
						<td width="2%" bgcolor="#000000"></td>
						<td width="50%"></td>
					</tr>
					<tr valign="top">
					  <td colspan="3" style="font-size: .7em;" align="center">Código <xsl:value-of select="comprobante/cabecera/informacion_comprobante/tipo_de_comprobante"/> </td>
					</tr>
					<tr height="100%">
						<td width="48%" height="100%"></td>
						<td width="1%" height="100%" bgcolor="#000000"></td>
						<td width="50%" height="100%"></td>
					</tr>
			      </table>
				</td>
				<td width="296" style="padding: 10px;">
				  <table width="100%" border="0" rules="none" cellspacing="0" cellpadding="0" align="center">
					<tr valign="top">
						<td style="font-size: 0.6em;" align="center">
						<xsl:if test="comprobante/cabecera/informacion_comprobante/Tipo_Codigo_Autorizacion = 'CAE'">
							COMPROBANTE ELECTRÓNICO
						</xsl:if>
						&nbsp;</td>
					</tr>
					<tr>
						<td align="center" style="font-size: 0.8em; padding: 5px; font-weight: bold;"> 
							<xsl:variable name="facdevuelto">
								<xsl:call-template name="factu"> 
									<xsl:with-param name="correspfactu" select="$tpofactura"/> 
								</xsl:call-template>
							</xsl:variable>
							<xsl:choose>
								  <xsl:when test="string-length($facdevuelto)!=0">
									<xsl:value-of select="$facdevuelto"/>
								</xsl:when>
								<xsl:otherwise>
									&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</xsl:otherwise>
							</xsl:choose>      
							<xsl:value-of select="concat(format-number(comprobante/cabecera/informacion_comprobante/punto_de_venta,'0000','european'),'-',format-number(comprobante/cabecera/informacion_comprobante/numero_comprobante,'00000000','european'))"/>
						</td>
					</tr>
					<tr>
						<td align="left" ><font size="-1">Original</font></td>
					</tr>
					<tr>
						<td align="left" ><font size="-2">Buenos Aires, 
			                  <xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_emision, 9)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_emision, 6,2)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_emision, 1,4)"/>
			                  </font>
						</td>
					</tr>
					<tr>
						<td align="left" valign="TOP"><font size="-2">CUIT <xsl:value-of select="comprobante/cabecera/informacion_vendedor/cuit"/></font>
						</td>
					</tr>
					<tr>
						<td align="left"><font size="-3">Ingresos Brutos: 
			                <xsl:choose>
						<xsl:when test="comprobante/cabecera/informacion_vendedor/condicion_ingresos_brutos = 02">Exento</xsl:when>
						<xsl:otherwise>Inscripto</xsl:otherwise>
						</xsl:choose>
			                &nbsp;<xsl:value-of select="comprobante/cabecera/informacion_vendedor/nro_ingresos_brutos"/></font></td>
					</tr>
					<tr>
						<td align="left"><font size="-3">Inicio de Actividades: <xsl:value-of select="comprobante/cabecera/informacion_vendedor/inicio_de_actividades"/></font></td>
					</tr>
				  </table>
				
				</td>
			  </tr>
			</table>
		  
          </td>
        </tr>
    </table>
    </td>
  </tr>
  <tr>
    <td valign="TOP"> 
      <table class="tabla_cabecera" width="100%" cellspacing="0" cellpadding="0">
       <tr>         
          <td width="60%" valign="top">
          	<table class="datos_cabecera" width="100%" cellpadding="0" cellspacing="0">
          		 <xsl:if test="comprobante/cabecera/informacion_comprador/denominacion != ''">
	          		<tr>
			          <td>Señores    : <xsl:value-of select="comprobante/cabecera/informacion_comprador/denominacion"/></td>
			        </tr>
		        </xsl:if>
		        <tr> 
		          <td>Domicilio  : 
		          		<!-- DOMICILIO COMPRADOR TOTALMENTE VALIDADO -->
			                <xsl:if test="comprobante/cabecera/informacion_comprador/domicilio_calle != ''">
			                	<xsl:value-of select="comprobante/cabecera/informacion_comprador/domicilio_calle"/>
			                </xsl:if>
			                <xsl:if test="comprobante/cabecera/informacion_comprador/domicilio_numero != ''">
			                	&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_comprador/domicilio_numero"/>
			                </xsl:if>
			                <xsl:if test="comprobante/cabecera/informacion_comprador/domicilio_piso != ''">
			                	&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_comprador/domicilio_piso"/>&ordm;
			                </xsl:if>
			                <xsl:if test="comprobante/cabecera/informacion_comprador/domicilio_depto != ''">
			                	&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_comprador/domicilio_depto"/>
			                </xsl:if>
			                <xsl:if test="comprobante/cabecera/informacion_comprador/domicilio_torre != ''">
			                	&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_comprador/domicilio_torre"/>
			                </xsl:if>
			                <xsl:if test="comprobante/cabecera/informacion_comprador/domicilio_sector != ''">
			                	&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_comprador/domicilio_sector"/>
			                </xsl:if>
			                <xsl:if test="comprobante/cabecera/informacion_comprador/domicilio_manzana != ''">
			                	&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_comprador/domicilio_manzana"/>
			                </xsl:if> (<xsl:value-of select="comprobante/cabecera/informacion_comprador/cp"/>). <xsl:value-of select="comprobante/cabecera/informacion_comprador/localidad"/>, <xsl:value-of select="comprobante/cabecera/informacion_comprador/provincia"/>
		          </td>
		        </tr>
		        <xsl:if test="comprobante/cabecera/informacion_comprador/GLN != ''">
			        <tr> 
			          <td>GLN  : <xsl:value-of select="comprobante/cabecera/informacion_comprador/GLN"/></td>
			        </tr>
			</xsl:if>
			<xsl:if test="comprobante/cabecera/informacion_comprador/codigo_doc_identificatorio != ''">
			        <tr> 
			          <td> 
			          	<xsl:variable name="docdevuelto">
					  	<xsl:call-template name="coddoc"> 
				            	<xsl:with-param name="correspdocs" select="$tipodoc"/> 
				          	</xsl:call-template>
						  </xsl:variable>
						  <xsl:choose>
							<xsl:when test="string-length($docdevuelto)!=0">
								<xsl:value-of select="$docdevuelto"/>
							</xsl:when>
							<xsl:otherwise>
								&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;&nbsp;
							</xsl:otherwise>
							</xsl:choose>  
						  <xsl:value-of select="comprobante/cabecera/informacion_comprador/nro_doc_identificatorio"/>
			          </td>
			        </tr>
		        </xsl:if>
		        <xsl:if test="comprobante/cabecera/informacion_comprador/condicion_ingresos_brutos != ''">
			        <tr> 
			          <td>Condición : 
					  <xsl:variable name="ivacdevuelto">
							<xsl:call-template name="condiva"> 
			       				<xsl:with-param name="correspcondiva" select="$condicivac"/> 
			         		</xsl:call-template>
					  </xsl:variable>
			   		  <xsl:choose>
						<xsl:when test="string-length($ivacdevuelto)!=0">
					  		<xsl:value-of select="$ivacdevuelto"/>
						</xsl:when>
						<xsl:otherwise>
							&nbsp;&nbsp;-&nbsp;&nbsp;
						</xsl:otherwise>
					  </xsl:choose>
					  , Ingresos Brutos 
						  <xsl:choose>
							<xsl:when test="comprobante/cabecera/informacion_comprador/condicion_ingresos_brutos = 02">Exento</xsl:when>
							<xsl:otherwise>Inscripto</xsl:otherwise>
						</xsl:choose>
					   &nbsp;Nro: <xsl:value-of select="comprobante/cabecera/informacion_comprador/nro_ingresos_brutos"/>
					  </td>
			        </tr>
		        </xsl:if>
		        <xsl:if test="comprobante/cabecera/informacion_comprador/inicio_actividades != ''">
			        <tr> 
			          <td>
				     Inicio de actividades: <xsl:value-of select="substring(comprobante/cabecera/informacion_comprador/inicio_actividades,9)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprador/inicio_actividades,6,2)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprador/inicio_actividades,1,4)"/>
			          </td>
			        </tr>
		        </xsl:if>
		         <xsl:if test="comprobante/cabecera/informacion_comprador/contacto != ''">
			        <tr> 
			          <td><xsl:value-of select="comprobante/cabecera/informacion_comprador/contacto"/>&nbsp;&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_comprador/email"/>&nbsp;&nbsp;<xsl:value-of select="comprobante/cabecera/informacion_comprador/telefono"/></td>
			        </tr>
			 </xsl:if>
          	</table>
          </td>
          <td width="40%" valign="top">
          	<table class="datos_cabecera" width="100%" cellspacing="0" cellpadding="0">
          		 <xsl:if test="comprobante/cabecera/informacion_vendedor/codigo_interno != ''">
	          		<tr> 
			          <td>Cliente nº  <xsl:value-of select="comprobante/cabecera/informacion_vendedor/codigo_interno"/></td>
			        </tr>
			 </xsl:if>
		        <tr> 
		          <td>
		          <xsl:if test="comprobante/cabecera/informacion_comprobante/fecha_serv_desde != ''">
			          Servicio desde <xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_serv_desde,9)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_serv_desde,6,2)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_serv_desde,1,4)"/>
			  </xsl:if>
			  <xsl:if test="comprobante/cabecera/informacion_comprobante/fecha_serv_hasta != ''">
			          hasta <xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_serv_hasta,9)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_serv_hasta,6,2)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_serv_hasta,1,4)"/>
			  </xsl:if>
		          </td>
		        </tr>
		        <xsl:if test="comprobante/cabecera/informacion_comprobante/fecha_vencimiento != ''">
			        <tr> 
			          <td>Fecha de Vencimiento: 
			            <xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_vencimiento,9)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_vencimiento,6,2)"/>-<xsl:value-of select="substring(comprobante/cabecera/informacion_comprobante/fecha_vencimiento,1,4)"/></td>
			        </tr>
			</xsl:if>
			<xsl:if test="comprobante/cabecera/informacion_comprobante/condicion_de_pago != ''">
			        <tr> 
			          <td>Condición de pago: <xsl:value-of select="comprobante/cabecera/informacion_comprobante/condicion_de_pago"/></td>
			        </tr>
			</xsl:if>
		        <xsl:for-each select="comprobante/cabecera/informacion_comprobante/referencias">
				<xsl:choose>
					<xsl:when test="codigo_de_referencia = 01">
						<tr><td>
							Número de orden de compra
							<xsl:value-of select="dato_de_referencia"/>
						</td></tr>
					</xsl:when>
					<xsl:when test="codigo_de_referencia = 02">
						<tr><td>
							Número de remito
							<xsl:value-of select="dato_de_referencia"/>
						</td></tr>
					</xsl:when>
					<xsl:when test="codigo_de_referencia = 03">
						<tr><td>
							Número de factura de referencia
							<xsl:value-of select="dato_de_referencia"/>
						</td></tr>
					</xsl:when>
					<xsl:when test="codigo_de_referencia = 04">
						<tr><td>
							Número nota de credito
							<xsl:value-of select="dato_de_referencia"/>
						</td></tr>
					</xsl:when>
				</xsl:choose>
		        </xsl:for-each>
          	</table>
          </td>
        </tr>
		
		<!-- Aca iran los datos comerciales estructurados -->
		<xsl:if test="comprobante/extensiones/extensiones_datos_comerciales != ''">
			<tr class="datos_cabecera"><td colspan="2"><hr/>
			  Datos comerciales estructurados (ver extensión)
			</td></tr>
		</xsl:if>
		<!-- Aca van los datos comerciales desestructurados --> 
		<xsl:if test="comprobante/extensiones/extensiones_datos_marketing/cabecera != ''">
			<!-- http://scriptasylum.com/tutorials/encdec/encode-decode.html -->
			<tr><td colspan="2">
			  <div id="div_MKT_header" style="max-height: 150px; overflow: hidden; height: expression( this.scrollHeight > 150 ? '151px' : 'hidden' );"></div>
			  <script>LevantarArchivoLinksValidos("div_MKT_header");</script>
			  </td></tr> 
		</xsl:if>
	  
     </table>
    </td>
  </tr>


  
  

  <!-- COMIENZO DE DETALLE -->
  
  <xsl:if test="comprobante/resumen/codigo_moneda != 'PES'">
        <tr><td colspan="4" align="center"><font size="-2.5">
        	Los importes de la factura están expresados en
        	<xsl:variable name="monedaletras">
			<xsl:call-template name="codmonedaletras"> 
				<xsl:with-param name="codigomonedaletras" select="$codmon"/> 
			</xsl:call-template>
		</xsl:variable>
		<xsl:value-of select="$monedaletras"/>
        	<xsl:variable name="moneda">
			<xsl:call-template name="codmoneda"> 
				<xsl:with-param name="codigomoneda" select="$codmon"/> 
			</xsl:call-template>
		</xsl:variable>
		&nbsp;(<xsl:value-of select="$moneda"/>).<br></br>
        	El tipo de cambio tomado para esta moneda extranjera es &nbsp;<xsl:value-of select="substring-before(string(comprobante/resumen/tipo_de_cambio),6)"/>
        </font></td></tr>
  </xsl:if>
  
  <tr><td>
   <table border="0" cellspacing="0" cellpadding="0" height="100%">
    <tr> <!-- height="60%" -->
    <td valign="top"> 
      <table width="663" rules="none" border="0" cellspacing="0">
        <tr>
          <td valign="TOP" width="661"> 
            <table width="100%" rules="none" border="0" cellspacing="0">
              <tr> 
                <td style="border-left: 1px solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="31%">&nbsp;DESCRIPCION</td>
                <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="11%" align="CENTER">CANT/ UNI</td>
                <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="10%" align="CENTER">PRECIO/ UNIT</td>
                <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="10%" align="CENTER">IMPORTE
                <xsl:if test="comprobante/resumen/codigo_moneda != 'PES'">
	                <xsl:variable name="moneda">
				<xsl:call-template name="codmoneda"> 
					<xsl:with-param name="codigomoneda" select="$codmon"/> 
				</xsl:call-template>
			</xsl:variable>
			<br></br>(<xsl:value-of select="$moneda"/>)
		</xsl:if>
                </td>
                <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="10%" align="CENTER">IVA ALIC.</td>
                <td style="border-right: 1px solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="10%" align="RIGHT">&nbsp;&nbsp;IMP.&nbsp;&nbsp;IVA.
		<xsl:if test="comprobante/resumen/codigo_moneda != 'PES'">
			<xsl:variable name="moneda">
				<xsl:call-template name="codmoneda"> 
					<xsl:with-param name="codigomoneda" select="$codmon"/> 
				</xsl:call-template>
			</xsl:variable>
			<br></br>(<xsl:value-of select="$moneda"/>)
		</xsl:if>
                </td>
              </tr>
              <!-- <tr> 
                <td width="51%" align="LEFT"><font size="-2.5"> </font></td>
                <td width="10%" align="CENTER"><font size="-2.5"> </font></td>
                <td width="11%" align="CENTER">&nbsp;</td>
                <td width="10%" align="CENTER"><font size="-2.5"> </font></td>
                <td width="10%" align="CENTER"><font size="-2.5"> </font></td>
                <td width="18%" align="RIGHT">&nbsp;</td>
              </tr> -->
              <xsl:for-each select="comprobante/detalle/linea">
              <xsl:variable name="color" select="(position() mod 2)"/>
              	<xsl:variable name="labelid" select="concat('label', position())"/>
              	<xsl:if test="(position() mod 2) = 0">
              		<tr bgcolor="#FFFFFF">
              		<td width="61%" align="LEFT" style="font-size:11px">
              			<xsl:value-of select="codigo_producto_vendedor"/>
              			<xsl:if test="GTIN != ''">
              				(<xsl:value-of select="GTIN"/>)&nbsp;
              			</xsl:if>
              			<xsl:value-of select="descripcion"/>
              			<xsl:if test="indicacion_exento_gravado != ''">
              				(<xsl:value-of select="indicacion_exento_gravado"/>)&nbsp;
              			</xsl:if>
              		</td>
                	<td width="11%" align="CENTER" style="font-size:11px"><font size="-2.5"><xsl:value-of select="cantidad"/>&nbsp;
                		<label title="">
                		<xsl:attribute name="id"><xsl:value-of select="$labelid"/></xsl:attribute></label>
                		<script>
                			transformarUnidades('<xsl:value-of select="$labelid"/>','<xsl:value-of select="unidad"/>');
                		</script>
                	</font></td>
                	<td width="10%" align="CENTER" style="font-size:11px"><font size="-2.5">
                	<xsl:if test="../../resumen/codigo_moneda != 'PES'">
                		<xsl:value-of select="importes_moneda_origen/precio_unitario"/>
                	</xsl:if>
                	<xsl:if test="../../resumen/codigo_moneda = 'PES'">
                		<xsl:value-of select="precio_unitario"/>
                	</xsl:if>
                	</font></td>
                	<td width="10%" align="CENTER" style="font-size:11px"><font size="-2.5"><b>
                	<xsl:if test="../../resumen/codigo_moneda != 'PES'">
                		<xsl:value-of select="format-number(importes_moneda_origen/importe_total_articulo,'#########0,00','european')"/>
                	</xsl:if>
                	<xsl:if test="../../resumen/codigo_moneda = 'PES'">
                		<xsl:value-of select="format-number(importe_total_articulo,'#########0,00','european')"/>
                	</xsl:if>
                	</b></font></td>
                	<td width="18%" align="CENTER" style="font-size:11px"><font size="-2.5">
                		<xsl:if test="alicuota_iva != ''">
                			<xsl:value-of select="alicuota_iva"/> %
                		</xsl:if></font>
                	</td>
                	<td width="18%" align="CENTER" style="font-size:11px">
                	<xsl:if test="../../resumen/codigo_moneda != 'PES'">
	                	<font size="-2.5"><xsl:value-of select="importes_moneda_origen/importe_iva"/></font>
	                </xsl:if>
	                <xsl:if test="../../resumen/codigo_moneda = 'PES'">
	                	<font size="-2.5"><xsl:value-of select="importe_iva"/></font>
			</xsl:if>
                	</td>
              		</tr>
              	</xsl:if>
              	<xsl:if test="(position() mod 2) != 0">
                	<tr bgcolor="#DDDDDD">
                	<td width="61%" align="LEFT" style="font-size:11px">
                		<xsl:value-of select="codigo_producto_vendedor"/>
              			<xsl:if test="GTIN != ''">
              				(<xsl:value-of select="GTIN"/>)&nbsp;
              			</xsl:if>
              			<xsl:value-of select="descripcion"/>
              			<xsl:if test="indicacion_exento_gravado != ''">
              				(<xsl:value-of select="indicacion_exento_gravado"/>)&nbsp;
              			</xsl:if>
                	</td>
                	<td width="11%" align="CENTER" style="font-size:11px"><font size="-2.5"><xsl:value-of select="cantidad"/>&nbsp;
                		<label>
                		<xsl:attribute name="id"><xsl:value-of select="$labelid"/></xsl:attribute></label>
                		<script>
                			transformarUnidades('<xsl:value-of select="$labelid"/>','<xsl:value-of select="unidad"/>');
                		</script>
                	</font></td>
                	<td width="10%" align="CENTER" style="font-size:11px"><font size="-2.5">
                	<xsl:if test="../../resumen/codigo_moneda != 'PES'">
                		<xsl:value-of select="importes_moneda_origen/precio_unitario"/>
                	</xsl:if>
                	<xsl:if test="../../resumen/codigo_moneda = 'PES'">
                		<xsl:value-of select="precio_unitario"/>
                	</xsl:if>
                	</font></td>
                	<td width="10%" align="CENTER" style="font-size:11px"><font size="-2.5"><b>
                	<xsl:if test="../../resumen/codigo_moneda != 'PES'">
                		<xsl:value-of select="format-number(importes_moneda_origen/importe_total_articulo,'#########0,00','european')"/>
                	</xsl:if>
                	<xsl:if test="../../resumen/codigo_moneda = 'PES'">
                		<xsl:value-of select="format-number(importe_total_articulo,'#########0,00','european')"/>
                	</xsl:if>
                	</b></font></td>
                	<td width="18%" align="CENTER" style="font-size:11px"><font size="-2.5">
                		<xsl:if test="alicuota_iva != ''">
                			<xsl:value-of select="alicuota_iva"/> %
                		</xsl:if></font>
                	</td>
                	<td width="18%" align="CENTER" style="font-size:11px">
                		<xsl:if test="../../resumen/codigo_moneda != 'PES'">
	                			<font size="-2.5"><xsl:value-of select="importes_moneda_origen/importe_iva"/></font>
	                	</xsl:if>
	                	<xsl:if test="../../resumen/codigo_moneda = 'PES'">
	                			<font size="-2.5"><xsl:value-of select="importe_iva"/></font>
				</xsl:if>
                	</td>
	      		</tr>
	      	</xsl:if>
	      	<xsl:for-each select="descuentos">
	      	<xsl:choose>
			<xsl:when test="porcentaje_descuento != 0">
					<xsl:if test="$color = 0">
						<tr bgcolor = "#FFFFFF"> 
				                	<td width="51%" align="LEFT"> <font size="-2.5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<xsl:value-of select="descripcion_descuento"/>&nbsp;&nbsp;&nbsp;(<xsl:value-of select="format-number(porcentaje_descuento,'#########0,00','european')"/> %)</font></td>
				                	<td width="11%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
				                	<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
				                	<xsl:choose>
				                		<xsl:when test="../../resumen/codigo_moneda != 'PES'">
				                			<td width="18%" align="CENTER"><font size="-2.5">-&nbsp;<xsl:value-of select="format-number(importe_descuento_moneda_origen,'#########0,00','european')"/></font></td>
				                		</xsl:when>
				                		<xsl:otherwise>
				                			<td width="10%" align="CENTER"><font size="-2.5">-&nbsp;<xsl:value-of select="format-number(importe_descuento,'#########0,00','european')"/></font></td>
				                		</xsl:otherwise>
				                	</xsl:choose>
				                	<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
				                	<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td> 
					      	</tr>
					</xsl:if>
					<xsl:if test="$color != 0">
						<tr bgcolor = "#DDDDDD"> 
				                	<td width="51%" align="LEFT"> <font size="-2.5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<xsl:value-of select="descripcion_descuento"/>&nbsp;&nbsp;&nbsp;(<xsl:value-of select="format-number(porcentaje_descuento,'#########0,00','european')"/> %)</font></td>
				                	<td width="11%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
				                	<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
				                	<xsl:choose>
				                		<xsl:when test="../../resumen/codigo_moneda != 'PES'">
				                			<td width="18%" align="CENTER"><font size="-2.5">-&nbsp;<xsl:value-of select="format-number(importe_descuento_moneda_origen,'#########0,00','european')"/></font></td>
				                		</xsl:when>
				                		<xsl:otherwise>
				                			<td width="10%" align="CENTER"><font size="-2.5">-&nbsp;<xsl:value-of select="format-number(importe_descuento,'#########0,00','european')"/></font></td>
				                		</xsl:otherwise>
				                	</xsl:choose>
				                	<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
				                	<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
					      	</tr>
					</xsl:if>
			</xsl:when>
		</xsl:choose>
		</xsl:for-each>
		<xsl:if test="importe_total_descuentos != ''">
			<xsl:if test="$color = 0">
				 <xsl:if test="importe_total_impuestos != ''">
				 	<tr height="20" bgcolor="#FFFFFF">
				 	<td width="51%" align="LEFT"><font size="-2.5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Importe total descuentos:</font></td>
					 <td colspan="2">&nbsp;</td>
					 <td width="18%" align="center"><font size="-2.5">
					 <xsl:if test="../../resumen/codigo_moneda != 'PES'">
					 	<xsl:if test="importes_moneda_origen/importe_total_descuentos != 0">
					 		-&nbsp;
					 	</xsl:if>
					 	<xsl:value-of select="importes_moneda_origen/importe_total_descuentos"/>
					 </xsl:if>
					 <xsl:if test="../../resumen/codigo_moneda = 'PES'">
					 	<xsl:if test="importe_total_descuentos != 0">
					 		-&nbsp;
					 	</xsl:if>
					 	<xsl:value-of select="importe_total_descuentos"/>
					 </xsl:if>
					 </font></td>
				 	 <td>&nbsp;</td>
				 	 <td align="CENTER"><font size="-2.5">&nbsp;</font></td>
				 	</tr>
				 </xsl:if>
			</xsl:if>
			<xsl:if test="$color != 0">
				 <xsl:if test="importe_total_impuestos != ''">
				 	<tr height="20" bgcolor="#DDDDDD">
				 	<td width="51%" align="LEFT"><font size="-2.5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Importe total descuentos:</font></td>
					 <td colspan="2">&nbsp;</td>
					 <td width="18%" align="center"><font size="-2.5">
					 <xsl:if test="../../resumen/codigo_moneda != 'PES'">
					 	<xsl:if test="importes_moneda_origen/importe_total_descuentos != 0">
					 		-&nbsp;
					 	</xsl:if>
					 	<xsl:value-of select="importes_moneda_origen/importe_total_descuentos"/>
					 </xsl:if>
					 <xsl:if test="../../resumen/codigo_moneda = 'PES'">
					 	<xsl:if test="importe_total_descuentos != 0">
					 		-&nbsp;
					 	</xsl:if>
					 	<xsl:value-of select="importe_total_descuentos"/>
					 </xsl:if>
					 </font></td>
				 	 <td>&nbsp;</td>
				 	 <td align="CENTER"><font size="-2.5">&nbsp;</font></td>
				 	 </tr>
				 </xsl:if>
			</xsl:if>
		</xsl:if>
		<xsl:for-each select="impuestos">
			<xsl:choose>
				<xsl:when test="porcentaje_impuesto != 0">
					 	<xsl:if test="$color = 0">
							<tr bgcolor="#FFFFFF"> 
					                	<td width="51%" valign="middle"> <font size="-2.5">
						                	&nbsp;&nbsp;&nbsp;(<xsl:value-of select="codigo_impuesto"/>)&nbsp;&nbsp;&nbsp;<xsl:value-of select="descripcion_impuesto"/>&nbsp;&nbsp;&nbsp;(<xsl:value-of select="format-number(porcentaje_impuesto,'#########0,00','european')"/> %)	
						                </font></td>
					                	<td width="11%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
					                	<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
					                	<xsl:choose>
					                		<xsl:when test="../../resumen/codigo_moneda != 'PES'">
					                			<td width="18%" align="CENTER"><font size="-2.5">&nbsp;<xsl:value-of select="format-number(importe_impuesto_moneda_origen,'#########0,00','european')"/></font></td>
					                		</xsl:when>
					                		<xsl:otherwise>
					                			<td width="10%" align="CENTER"><font size="-2.5"><xsl:value-of select="format-number(importe_impuesto,'#########0,00','european')"/></font></td>
					                		</xsl:otherwise>
				                		</xsl:choose>
				                		<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
				                		<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td> 
						      	</tr>
						</xsl:if>
						<xsl:if test="$color != 0">
							<tr bgcolor="#DDDDDD"> 
					                	<td width="51%" valign="middle"> <font size="-2.5">
						                	&nbsp;&nbsp;&nbsp;(<xsl:value-of select="codigo_impuesto"/>)&nbsp;&nbsp;&nbsp;<xsl:value-of select="descripcion_impuesto"/>&nbsp;&nbsp;&nbsp;(<xsl:value-of select="format-number(porcentaje_impuesto,'#########0,00','european')"/> %)
						                </font></td>
					                	<td width="11%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
					                	<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
					                	<xsl:choose>
					                		<xsl:when test="../../resumen/codigo_moneda != 'PES'">
					                			<td width="18%" align="CENTER"><font size="-2.5">&nbsp;<xsl:value-of select="format-number(importe_impuesto_moneda_origen,'#########0,00','european')"/></font></td>
					                		</xsl:when>
					                		<xsl:otherwise>
					                			<td width="10%" align="CENTER"><font size="-2.5"><xsl:value-of select="format-number(importe_impuesto,'#########0,00','european')"/></font></td>
					                		</xsl:otherwise>
				                		</xsl:choose>
				                		<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>
				                		<td width="10%" align="CENTER"><font size="-2.5">&nbsp;</font></td>  
						      	</tr>
						</xsl:if>
				</xsl:when>
			</xsl:choose>
		</xsl:for-each>
			<xsl:if test="importe_total_impuestos != ''">
				 <xsl:if test="$color = 0">
				 	 <tr bgcolor="#FFFFFF">
					 <td width="51%" align="LEFT"><font size="-2.5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Importe total impuestos:</font></td>
					 <td colspan="2">&nbsp;</td>
					 <td width="18%" align="center"><font size="-2.5">&nbsp;
					 <xsl:if test="../../resumen/codigo_moneda != 'PES'">
					 	<xsl:value-of select="importes_moneda_origen/importe_total_impuestos"/>
					 </xsl:if>
					 <xsl:if test="../../resumen/codigo_moneda = 'PES'">
					 	<xsl:value-of select="importe_total_impuestos"/>
					 </xsl:if>
					 </font></td>
					 <td>&nbsp;</td>
					 <td align="CENTER"><font size="-2.5">&nbsp;</font></td>
					</tr>
				</xsl:if>
				<xsl:if test="$color != 0">
					 <tr bgcolor="#DDDDDD">
					 <td width="51%" align="LEFT"><font size="-2.5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Importe total impuestos:</font></td>
					 <td colspan="2">&nbsp;</td>
					 <td width="18%" align="center"><font size="-2.5">&nbsp;
					 <xsl:if test="../../resumen/codigo_moneda != 'PES'">
					 	<xsl:value-of select="importes_moneda_origen/importe_total_impuestos"/>
					 </xsl:if>
					 <xsl:if test="../../resumen/codigo_moneda = 'PES'">
					 	<xsl:value-of select="importe_total_impuestos"/>
					 </xsl:if>
					 </font></td>
					 <td>&nbsp;</td>
					 <td align="CENTER"><font size="-2.5">&nbsp;</font></td>
					</tr>
				</xsl:if>
			</xsl:if>
			<tr style="height:2px"><td colspan="6" style="border-top:1px solid #999999"></td></tr>
              </xsl:for-each>
              <tr>
                <td width="61%" align="LEFT"><font size="-2.5"> </font></td>
                <td width="10%" align="CENTER"><font size="-2.5"> </font></td>
                <td width="11%" align="CENTER">&nbsp;</td>
                <td width="18%" align="CENTER">&nbsp;</td>
              </tr>
            </table>
          </td>
        </tr></table>
	</td></tr>
	
	<tr><td><hr/></td></tr>
	<!-- Lugar para comentarios -->
	<tr><td width="100%">
		<font size="-2"><xsl:value-of select="comprobante/detalle/comentarios"/>
		</font>
	</td></tr>
	
	
	<!-- DESCUENTOS GLOBALES -->
	<tr><td>
	<xsl:if test="comprobante/resumen/descuentos/importe_descuento != ''">
		<table width="100%" rules="none" border="0" cellspacing="0">
			<tr>
				<td style="border-left: 1px solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="50%">&nbsp;Descuento Global &nbsp;&nbsp;(%)</td>
		                <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="20%" align="CENTER">Importe Dto.
		                <xsl:if test="comprobante/resumen/codigo_moneda != 'PES'">
					<xsl:variable name="moneda">
						<xsl:call-template name="codmoneda"> 
							<xsl:with-param name="codigomoneda" select="$codmon"/> 
						</xsl:call-template>
					</xsl:variable>
					(<xsl:value-of select="$moneda"/>)
				</xsl:if>
		                </td>
		                <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="10%" align="CENTER">Alicuota</td>
		                <td style="border-right: 1px solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="20%" align="CENTER">Importe IVA Dto.
		                <xsl:if test="comprobante/resumen/codigo_moneda != 'PES'">
					<xsl:variable name="moneda">
						<xsl:call-template name="codmoneda"> 
							<xsl:with-param name="codigomoneda" select="$codmon"/> 
						</xsl:call-template>
					</xsl:variable>
					(<xsl:value-of select="$moneda"/>)
				</xsl:if>
		                </td>
			</tr>
			<xsl:for-each select="comprobante/resumen/descuentos">
			<tr>
				<td width="50%" align="LEFT">  <font size="-2.5"><xsl:value-of select="descripcion_descuento"/>
				<xsl:if test="porcentaje_descuento != ''">
					&nbsp;&nbsp;&nbsp;(<xsl:value-of select="porcentaje_descuento"/> %)
				</xsl:if>
				</font></td>
				<xsl:if test="../../resumen/codigo_moneda != 'PES'">
			                <td width="20%" align="CENTER"><font size="-2.5">
			                	<xsl:if test="importe_descuento_moneda_origen != 0">
			                		-&nbsp;
			                	</xsl:if>
			                	<xsl:value-of select="importe_descuento_moneda_origen"/>
			                </font></td>
			        </xsl:if>
			        <xsl:if test="../../resumen/codigo_moneda = 'PES'">
			                <td width="20%" align="CENTER"><font size="-2.5">
			                	<xsl:if test="importe_descuento != 0">
			                		-&nbsp;
			                	</xsl:if>
			                	<xsl:value-of select="importe_descuento"/>
			                </font></td>
			        </xsl:if>
		                
		                <td width="10%" align="CENTER"><font size="-2.5">
					<xsl:value-of select="alicuota_iva_descuento"/>
		                </font></td>
		                <xsl:if test="../../resumen/codigo_moneda != 'PES'">
			                <td width="20%" align="CENTER"><font size="-2.5">
			                <xsl:if test="importe_iva_descuento_moneda_origen != ''">
						<xsl:value-of select="importe_iva_descuento_moneda_origen "/>
					</xsl:if>
			                </font></td>
			        </xsl:if>
			        <xsl:if test="../../resumen/codigo_moneda = 'PES'">
			                <td width="20%" align="CENTER"><font size="-2.5">
			                <xsl:if test="importe_iva_descuento != ''">
						<xsl:value-of select="importe_iva_descuento "/>
					</xsl:if>
			                </font></td>
			        </xsl:if>
			</tr>
			</xsl:for-each>
		</table>
	</xsl:if>
	</td></tr>

	<!-- IMPUESTOS GLOBALES -->
	<tr><td>
	<xsl:if test="comprobante/resumen/impuestos/codigo_impuesto != ''">
		<table width="100%" rules="none" border="0" cellspacing="0">
			<tr>
				<td style="border-left: 1px solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="30%">&nbsp;Impuesto Global</td>
		                <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="40%" align="CENTER">Jurisdiccion</td>
		                <td style="border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="10%" align="CENTER">% Impuesto</td>
		                <td style="border-right: 1px solid #000000; border-top: 1px solid #000000; border-bottom: 1px solid #000000; font-size:11px" width="20%" align="CENTER">Importe
		                <xsl:if test="comprobante/resumen/codigo_moneda != 'PES'">
					<xsl:variable name="moneda">
						<xsl:call-template name="codmoneda"> 
							<xsl:with-param name="codigomoneda" select="$codmon"/> 
						</xsl:call-template>
					</xsl:variable>
					(<xsl:value-of select="$moneda"/>)
				</xsl:if>
		                </td>
			</tr>
			<xsl:for-each select="comprobante/resumen/impuestos">
			<tr>
				<td width="30%" align="LEFT">  <font size="-2.5"><xsl:value-of select="codigo_impuesto"/> - <xsl:value-of select="descripcion"/></font></td>
			        <td width="40%" align="CENTER"><font size="-2.5">
			               <xsl:value-of select="codigo_jurisdiccion"/> - <xsl:value-of select="jurisdiccion_municipal"/>
			        </font></td>
		                <xsl:if test="porcentaje_impuesto != ''">
			                <td width="10%" align="CENTER"><font size="-2.5">
						<xsl:value-of select="porcentaje_impuesto"/> %
			                </font></td>
			        </xsl:if>
			        <xsl:if test="pocentaje_impuesto = ''">
			        	<td>&nbsp;</td>
			        </xsl:if>
		                <xsl:if test="../../resumen/codigo_moneda != 'PES'">
			                <td width="10%" align="CENTER"><font size="-2.5">
			                <xsl:if test="importe_impuesto_moneda_origen != ''">
						<xsl:value-of select="importe_impuesto_moneda_origen "/>
					</xsl:if>
			                </font></td>
			        </xsl:if>
			        <xsl:if test="../../resumen/codigo_moneda = 'PES'">
			                <td width="20%" align="CENTER"><font size="-2.5">
			                <xsl:if test="importe_impuesto != ''">
						<xsl:value-of select="importe_impuesto "/>
					</xsl:if>
			                </font></td>
			        </xsl:if>
			</tr>
			</xsl:for-each>
		</table>
	</xsl:if>
	</td></tr>
	
	
	<!-- COMIENZO DE CUADRO RESUMEN -->
	
	<tr><td>
	<xsl:variable name="tipofacdevuelto2">
	<xsl:call-template name="tipofactu"> 
           	<xsl:with-param name="corresptipofactu" select="$tpofactura"/> 
        </xsl:call-template>
	</xsl:variable>
	<xsl:if test="$tipofacdevuelto2 = 'B'">
		<tr><td align="center"><font size="-2.5">
		El importe del IVA discriminado no es computable como crédito fiscal.
		</font></td></tr><tr><td>&nbsp;</td></tr>
	</xsl:if>
	</td></tr>
    <tr>    <!-- style="height:40%"-->
    <td valign="bottom">
      <table width="100%" border="1" cellspacing="0" frame="border" bordercolor="#000000" rules="none">
 
        <tr> 
          <td>&nbsp;</td>
          <td valign="middle"> 
          <table width="96%" border="2" cellspacing="0" bordercolor="#000000" rules="none">
              <tr> 
                <td>&nbsp;</td>
              </tr>
              <tr> 
                <td><font size="-1"> <font face="Arial, Helvetica, sans-serif"> C.A.E. 
                  - Código de Autorización Electrónico</font></font></td>
              </tr>
              <tr> 
                <td><font size="-1">  <font face="Arial, Helvetica, sans-serif"><xsl:value-of select="comprobante/cabecera/informacion_comprobante/cae"/>- 
                  Vto <xsl:value-of select="comprobante/cabecera/informacion_comprobante/fecha_vencimiento_cae"/></font></font></td>
              </tr>
			<xsl:variable name="tipofacdevuelto3">
			<xsl:call-template name="tipofactu"> 
		           	<xsl:with-param name="corresptipofactu" select="$tpofactura"/> 
		        </xsl:call-template>
			</xsl:variable>
			<xsl:if test="$tipofacdevuelto3 = 'A'">
				<xsl:if test="comprobante/cabecera/informacion_comprobante/motivo != ''">
					<tr><td align="left"><font size="-1"> <font face="Arial, Helvetica, sans-serif">&nbsp;
						<xsl:value-of select="comprobante/cabecera/informacion_comprobante/resultado"/> (<xsl:value-of select="comprobante/cabecera/informacion_comprobante/motivo"/>)	
					</font></font></td></tr>
				</xsl:if>
			</xsl:if>
              <tr> 
                <td>&nbsp;</td>
              </tr>
            </table>
          </td>
          <td colspan="2" valign="top" style="font-size: 11px">
          <table width="91%" border="0" cellspacing="0" cellpadding="0">
               <tr> 
                <td width="65%" valign="middle">&nbsp;</td>
                <xsl:choose>
                <xsl:when test="comprobante/resumen/codigo_moneda != 'PES'">
	                <td width="15%" align="RIGHT" style="font-family:Tahoma">
		               	<xsl:variable name="moneda">
				<xsl:call-template name="codmoneda"> 
			           	<xsl:with-param name="codigomoneda" select="$codmon"/> 
			        </xsl:call-template>
				</xsl:variable>
				<xsl:value-of select="$moneda"/>
				&nbsp;&nbsp;	
	                </td>
	                <td width="5%" align="CENTER">&nbsp;</td>
	                <td width="15%" align="RIGHT" style="font-family:Tahoma"> $&nbsp;&nbsp;&nbsp;</td>
              	</xsl:when>
              	<xsl:otherwise>
              		<td width="35%" align="RIGHT" style="font-family:Tahoma"> $&nbsp;&nbsp;&nbsp;</td>
              	</xsl:otherwise>
              	</xsl:choose>
              </tr>
              <xsl:choose>
                <xsl:when test="comprobante/resumen/codigo_moneda != 'PES'">
		              <tr>
		                <td width="65%" valign="middle">Importe total neto gravado: </td>
		                <td width="15%" align="RIGHT" style="border-top: 2px solid #000000"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/importe_total_neto_gravado,'#########0,00','european')"/></td>
		                <td width="5%" align="CENTER" style="border-top: 2px solid #000000">&nbsp;</td>
		                <td width="15%" align="RIGHT" style="border-top: 2px solid #000000"><xsl:value-of select="format-number(comprobante/resumen/importe_total_neto_gravado,'#########0,00','european')"/></td>
		              </tr>
		              <tr> 
		                <td valign="middle">Importe total concepto no gravado: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/importe_total_concepto_no_gravado,'#########0,00','european')"/></td>
		                <td align="CENTER">&nbsp;</td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_concepto_no_gravado,'#########0,00','european')"/></td>
		              </tr>
		              <tr> 
		                <td valign="middle">Importe de operaciones exentas: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/importe_operaciones_exentas,'#########0,00','european')"/></td>
		                <td align="CENTER">&nbsp;</td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_operaciones_exentas,'#########0,00','european')"/></td>
		              </tr>
		              <tr> 
		                <td valign="middle">Impuesto liq: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/impuesto_liq,'#########0,00','european')"/></td>
		                <td align="CENTER">&nbsp;</td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/impuesto_liq,'#########0,00','european')"/></td>
		              </tr>
		              <tr> 
		                <td valign="middle">Impuesto liq RNI: </td>
		                <td align="RIGHT" style="border-bottom: 2px solid #000000"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/impuesto_liq_rni,'#########0,00','european')"/></td>
		               	<td align="CENTER" style="border-bottom: 2px solid #000000">&nbsp;</td>
		                <td align="RIGHT" style="border-bottom: 2px solid #000000"><xsl:value-of select="format-number(comprobante/resumen/impuesto_liq_rni,'#########0,00','european')"/></td>
		              </tr>
		              <xsl:if test="comprobante/resumen/importe_total_impuestos_nacionales != ''">
		              <tr> 
		                <td valign="middle">Importe total de impuestos nacionales: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/importe_total_impuestos_nacionales,'#########0,00','european')"/></td>
		                <td align="CENTER">&nbsp;</td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_impuestos_nacionales,'#########0,00','european')"/></td>
		              </tr>
		              </xsl:if>  
		              <xsl:if test="comprobante/resumen/importe_total_ingresos_brutos != ''">
		              <tr> 
		                <td valign="middle">Importe total de ingresos brutos: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/importe_total_ingresos_brutos,'#########0,00','european')"/></td>
		                <td align="CENTER">&nbsp;</td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_ingresos_brutos,'#########0,00','european')"/></td>
		              </tr>
		              </xsl:if>
		              <xsl:if test="comprobante/resumen/importe_total_impuestos_municipales != ''">
		              <tr> 
		                <td valign="middle">Importe total de impuestos municipales: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/importe_total_impuestos_municipales,'#########0,00','european')"/></td>
		                <td align="CENTER">&nbsp;</td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_impuestos_municipales,'#########0,00','european')"/></td>
		              </tr>
		              </xsl:if>
		              <xsl:if test="comprobante/resumen/importe_total_impuestos_internos != ''">
		              <tr> 
		                <td valign="middle">Importe total de impuestos internos: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/importe_total_impuestos_internos,'#########0,00','european')"/></td>
		                <td align="CENTER">&nbsp;</td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_impuestos_internos,'#########0,00','european')"/></td> 
		              </tr>
		              </xsl:if>
		              <tr> 
		                <td valign="middle" height="25"><b>Importe total factura:</b></td>
		                <td align="RIGHT" height="25" style="border-bottom: 3px solid #000000; border-top: 2px solid #000000"><b><xsl:value-of select="format-number(comprobante/resumen/importes_moneda_origen/importe_total_factura,'#########0,00','european')"/></b></td>
		                <td align="CENTER" style="border-bottom: 3px solid #000000; border-top: 2px solid #000000">&nbsp;</td>
		                <td align="RIGHT" height="25" style="border-bottom: 3px solid #000000; border-top: 2px solid #000000"><b><xsl:value-of select="format-number(comprobante/resumen/importe_total_factura,'#########0,00','european')"/></b></td>
		              </tr>
              		</xsl:when>
              		<xsl:otherwise>
              		      <tr>
		                <td width="65%" valign="middle">Importe total neto gravado: </td>
		                <td width="35%" align="RIGHT" style="border-top: 2px solid #000000"><xsl:value-of select="format-number(comprobante/resumen/importe_total_neto_gravado,'#########0,00','european')"/></td>
		              </tr>
		              <tr> 
		                <td valign="middle">Importe total concepto no gravado: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_concepto_no_gravado,'#########0,00','european')"/></td>
		              </tr>
		              <tr> 
		                <td valign="middle">Importe de operaciones exentas: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_operaciones_exentas,'#########0,00','european')"/></td>
		              </tr>
		              <tr> 
		                <td valign="middle">Impuesto liq: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/impuesto_liq,'#########0,00','european')"/></td>
		              </tr>
		              <tr> 
		                <td valign="middle">Impuesto liq RNI: </td>
		                <td align="RIGHT" style="border-bottom: 2px solid #000000"><xsl:value-of select="format-number(comprobante/resumen/impuesto_liq_rni,'#########0,00','european')"/></td>
		              </tr>
		              <xsl:if test="comprobante/resumen/importe_total_impuestos_nacionales != ''">
		              <tr> 
		                <td valign="middle">Importe total de impuestos nacionales: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_impuestos_nacionales,'#########0,00','european')"/></td>
		              </tr>
		              </xsl:if>  
		              <xsl:if test="comprobante/resumen/importe_total_ingresos_brutos != ''">
		              <tr> 
		                <td valign="middle">Importe total de ingresos brutos: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_ingresos_brutos,'#########0,00','european')"/></td>
		              </tr>
		              </xsl:if>
		              <xsl:if test="comprobante/resumen/importe_total_impuestos_municipales != ''">
		              <tr> 
		                <td valign="middle">Importe total de impuestos municipales: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_impuestos_municipales,'#########0,00','european')"/></td> 
		              </tr>
		              </xsl:if>
		              <xsl:if test="comprobante/resumen/importe_total_impuestos_internos != ''">
		              <tr> 
		                <td valign="middle">Importe total de impuestos internos: </td>
		                <td align="RIGHT"><xsl:value-of select="format-number(comprobante/resumen/importe_total_impuestos_internos,'#########0,00','european')"/></td> 
		              </tr>
		              </xsl:if>
		              <tr> 
		                <td valign="middle" height="25"><b>Importe total factura:</b></td>
		                <td align="RIGHT" height="25" style="border-bottom: 3px solid #000000; border-top: 2px solid #000000"><b><xsl:value-of select="format-number(comprobante/resumen/importe_total_factura,'#########0,00','european')"/></b></td>
		              </tr>
              		</xsl:otherwise>
              	</xsl:choose>
            </table>
          </td>
        </tr>
        
        <tr> 
          <td height="30">&nbsp;</td>
          <td colspan="3" valign="top" style="font-size: 11px">
            <!-- Código para pegar la cadena de palabras del numero final (Poniendo la primer letra como mayuscula y poner "uno" en vez de "un" si es que la cadena termina con "un") -->
            <xsl:variable name="num-in-words3"> 
	            <xsl:call-template name="int2word"> 
	            	<xsl:with-param name="in-integer" select="format-number($number, '###.###.###.###.###', 'european')"/> 
	            </xsl:call-template> 
            </xsl:variable>
            <xsl:variable name="num-in-words2">	
            	<xsl:value-of select="translate(substring($num-in-words3,1,1), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ')"/>
            	<xsl:value-of select="substring(string($num-in-words3),2)"/> 
            </xsl:variable>
            <xsl:variable name="num-in-words">
            	<xsl:choose>
            		<xsl:when test="(substring($num-in-words2, string-length($num-in-words2)-2) = 'un ') or (substring($num-in-words2, string-length($num-in-words2)-2) = 'Un ')"> 
            			<xsl:value-of select="concat(substring($num-in-words2, 1, (string-length($num-in-words2)-1)),'o')"/> 
            		</xsl:when>
            		<xsl:otherwise>
            			<xsl:choose>
            				<xsl:when test="substring($num-in-words2,string-length($num-in-words2),1) = ' '"> 
            					<xsl:value-of select="substring($num-in-words2, 1, (string-length($num-in-words2)-1))"/> 
            				</xsl:when> 
            				<xsl:otherwise> 
            					<xsl:value-of select="$num-in-words2"/> 
            				</xsl:otherwise> 
            			</xsl:choose> 
            		</xsl:otherwise> 
            	</xsl:choose> 
            </xsl:variable> 
            <font size="-1">Son Pesos: </font> <font size="-1"> 
            <xsl:choose>
            	<xsl:when test="(number($number)) = 0"> 
            		Cero con 00/100.- 
            	</xsl:when> 
            	<xsl:otherwise> 
            		<xsl:value-of select="$num-in-words"/> con <xsl:value-of select="format-number((number($number) - number(format-number($number, '###############', 'european'))) * 100,'##', 'european')"/>/100.- 
            	</xsl:otherwise> 
            </xsl:choose>
            </font> 
            <!-- Fin de Código para pegar la cadena de palabras del numero final -->
            </td>
        </tr>
        <tr> 
          <td height="22">&nbsp;</td>
          <td colspan="3" valign="top" align="CENTER" style="font-size: 10px"><xsl:value-of select="comprobante/resumen/observaciones"/>	
          </td>
        </tr>
      </table>    
    </td>
  </tr>
 
	<!-- CODIGO DE BARRAS http://philippe.corbes.free.fr/codebarre/jsbarcode/index_en.html -->

	  <tr><td align="center" style="height: 10px; font-size: .8em; padding:5px;"><div align="center" id="barcode"></div>
	  </td></tr>
	
	  <xsl:variable name="codigoBarrasAux" select="concat(comprobante/cabecera/informacion_vendedor/cuit, comprobante/cabecera/informacion_comprobante/tipo_de_comprobante, comprobante/cabecera/informacion_comprobante/punto_de_venta, comprobante/cabecera/informacion_comprobante/cae, translate(comprobante/cabecera/informacion_comprobante/fecha_vencimiento,'-',''))"/>
	  <xsl:variable name="codigoBarrasDigit1" select="number(number(substring($codigoBarrasAux,1,1))+ number(substring($codigoBarrasAux,3,1))+ number(substring($codigoBarrasAux,5,1))+ number(substring($codigoBarrasAux,7,1))+ number(substring($codigoBarrasAux,9,1))+ number(substring($codigoBarrasAux,11,1))+ number(substring($codigoBarrasAux,13,1))+ number(substring($codigoBarrasAux,15,1))+ number(substring($codigoBarrasAux,17,1))+ number(substring($codigoBarrasAux,19,1))+ number(substring($codigoBarrasAux,21,1))+ number(substring($codigoBarrasAux,23,1))+ number(substring($codigoBarrasAux,25,1))+ number(substring($codigoBarrasAux,27,1))+ number(substring($codigoBarrasAux,29,1))+ number(substring($codigoBarrasAux,31,1))+ number(substring($codigoBarrasAux,33,1))+ number(substring($codigoBarrasAux,35,1))+ number(substring($codigoBarrasAux,37,1))+ number(substring($codigoBarrasAux,39,1)))"/>
	  <xsl:variable name="codigoBarrasDigit2" select="number(substring($codigoBarrasAux,2,1))+ number(substring($codigoBarrasAux,4,1))+ number(substring($codigoBarrasAux,6,1))+ number(substring($codigoBarrasAux,8,1))+ number(substring($codigoBarrasAux,10,1))+ number(substring($codigoBarrasAux,12,1))+ number(substring($codigoBarrasAux,14,1))+ number(substring($codigoBarrasAux,16,1))+ number(substring($codigoBarrasAux,18,1))+ number(substring($codigoBarrasAux,20,1))+ number(substring($codigoBarrasAux,22,1))+ number(substring($codigoBarrasAux,24,1))+ number(substring($codigoBarrasAux,26,1))+ number(substring($codigoBarrasAux,28,1))+ number(substring($codigoBarrasAux,30,1))+ number(substring($codigoBarrasAux,32,1))+ number(substring($codigoBarrasAux,34,1))+ number(substring($codigoBarrasAux,36,1))+ number(substring($codigoBarrasAux,38,1))"/>
	  <xsl:variable name="codigoBarrasDigit" select="(10 - number(substring((((number(($codigoBarrasDigit1))) * 3) + (number($codigoBarrasDigit2))), (number(string-length((((number(($codigoBarrasDigit1))) * 3) + (number($codigoBarrasDigit2)))))) - 1)))"/>
	  <xsl:choose>
		<xsl:when test="$codigoBarrasDigit = 10">
			<SCRIPT LANGUAGE='javascript'>
				  acode = new Code2of5()
				  acode.code     = '<xsl:value-of select="concat(codigoBarrasAux, '0')"/>'
				  acode.type     = 'CODE2OF5_INTERLEAVED'
				  acode.withtext = true
				  acode.xsize    = 1
				  acode.ysize    = 10
				  acode.xratio   = 3.0
				  acode.xinter   = 1
				  document.getElementById('barcode').innerHTML = acode.draw();
			</SCRIPT>
		</xsl:when>
	  	<xsl:otherwise>
	  		<SCRIPT LANGUAGE='javascript'>
				  acode = new Code2of5()
				  acode.code     = '<xsl:value-of select="concat($codigoBarrasAux, $codigoBarrasDigit)"/>'
				  acode.type     = 'CODE2OF5_INTERLEAVED'
				  acode.withtext = true
				  acode.xsize    = 1
				  acode.ysize    = 40
				  acode.xratio   = 3.0
				  acode.xinter   = 1
				  document.getElementById('barcode').innerHTML = acode.draw();
			</SCRIPT>
	  	</xsl:otherwise>
	  </xsl:choose>

  <!-- info desestructurada marketing -->
  	<xsl:if test="comprobante/extensiones/extensiones_datos_marketing != ''">
	 	<tr><td>
		<div id="div_MKT_pie"></div>
		<script>LevantarArchivoLinksValidos("div_MKT_pie");</script>
		</td></tr>
	</xsl:if>
  <!-- Fin de factura -->
  
  </table>
  </td></tr></table>

  <script>
  if (BrowserDetect.browser != 'Explorer') { 
	LevantarArchivoLinksValidos();
  } 
  </script>
</body>
</html>
</xsl:template>








<!-- Variables Diccionario -->

<xsl:variable name="int2word" select=" '1un|2dos|3tres|4cuatro|5cinco|6seis|7siete|8ocho|9nueve|10Diez|11Once|12Doce|13Trece|14Catorce|15Quince|16Dieciseis|17Diecisiete|18Dieciocho|19Diecinueve|' "/>
<xsl:variable name="tens2word" select=" '2Veinti|3Treinti|4Cuarenti|5Cincuenti|6Sesenti|7Setenti|8=Ochenti|9Noventi|' "/>
<xsl:variable name="tens2word2" select=" '2Veinte|3Treinta|4Cuarenta|5Cincuenta|6Sesenta|7Setenta|8Ochenta|9Noventa|' "/>
<xsl:variable name="thousands2word" select=" '3Mil|6Millones|9Mil Millones|12Billones|15Mil Billones|18Trillones|21Mil Trillones|24Cuatrillones|27Mil Cuatrillones|30Quintillones|33Mil Quintillones|36Sextillones|39Mil Sextillones|42Septillones|45Mil Septillones|48Octillones|51Mil Octillones|54Nonillones|57Mil Nonillones|60Decillones|63Mil Decillones|' "/>
<xsl:variable name="documentos" select=" '80CUIT|86CUIL|87CDI|89LE|90LC|91CI extranjera|92En trámite|93Acta nacimiento|95CI Bs. As. RNP|96DNI|94Pasaporte|00CI Policía Federal|01CI Buenos Aires|07CI Mendoza|08CI La Rioja|09CI Salta|10CI San Juan|11Ci Santa Fé|12CI San Luis|13CI Santiago del Estero|14CI Tucumán|16CI Chaco|17CI Chubut|18CI  Formosa|19CI Misiones|20CI Neuquén|' "/>
<xsl:variable name="factura" select=" '01Factura|02Nota de débito|03Nota de crédito|04Recibos|05Notas de Venta al contado|06Factura tipo|07Nota de débito|08Nota de crédito|09Recibos|10Notas de Venta al contado|39Otros comprobantes A que cumplan con la R.G. N° 3419|40Otros comprobantes B que cumplan con la R.G. N° 3419|60Cuenta de Venta y Líquido producto|61Cuenta de Venta y Líquido producto|63Liquidación|64Liquidación|' "/>
<xsl:variable name="tipofactura" select=" '01A|02A|03A|04A|05A|06B|07B|08B|09B|10B|39A|40B|60A|61B|63A|64B|' "/>
<xsl:variable name="condicioniva" select=" '01IVA Responsable inscripto|02IVA Responsable no inscripto|03IVA no responsable|04IVA Sujeto Exento|05Consumidor Final|06Responsable Monotributo|07Sujeto no categorizado|08Importador del exterior|09Cliente del Exterior|10IVA Liberado - Ley N° 19640|11IVA Responsable Inscripto - Agente de Percepción|' "/>
<xsl:variable name="jurisdicciones" select=" '1Capital Federal|2Buenos Aires|3Catamarca|4Córdoba|5Corrientes|6Chaco|7Chubut|9Formosa|10Jujuy|11La Pampa|12La Rioja|13Mendoza|14Misiones|15Neuquén|16Río Negro|17Salta|18San Juan|19San Luis|20Santa Cruz|21Santa Fe|22Santiago del Estero|23Tierra del Fuego|24Tucumán|' "/>

<xsl:variable name="monedasletra" select=" '0OTRAS MONEDAS|PESPESOS|DOLDólar ESTADOUNIDENSE|2Dólar EEUU LIBRE|3FRANCOS FRANCESES|4LIRAS ITALIANAS|5PESETAS|6MARCOS ALEMANES|7FLORINES HOLANDESES|8FRANCOS BELGAS|9FRANCOS SUIZOS|10PESOS MEJICANOS|11PESOS URUGUAYOS|12REAL|13ESCUDOS PORTUGUESES|14CORONAS DANESAS|15CORONAS NORUEGAS|16CORONAS SUECAS|17CHELINES AUTRIACOS|18Dólar CANADIENSE|19YENS|21LIBRA ESTERLINA|22MARCOS FINLANDESES|23BOLIVAR|24CORONA CHECA|25DINAR (YUGOSLAVO)|26Dólar AUSTRALIANO|27DRACMA (GRIEGO)|28FLORIN (ANTILLAS HOLA|29GUARANI|30SHEKEL (ISRAEL)|31PESO BOLIVIANO|32PESO COLOMBIANO|33PESO CHILENO|34RAND|35NUEVO SOL PERUANO|36SUCRE (ECUATORIANO)|40LEI RUMANOS|41DERECHOS ESPECIALES DE GIRO|42PESOS DOMINICANOS|43BALBOAS PANAMEÑAS|44CORDOBAS NICARAGÜENSES|45DIRHAM MARROQUÍES|46LIBRAS EGIPCIAS|47RIYALS SAUDITAS|48BRANCOS BELGAS FINANCIERAS|49GRAMOS DE ORO FINO|50LIBRAS IRLANDESAS|51Dólar DE HONG KONG|52Dólar DE SINGAPUR|53Dólar DE JAMAICA|54Dólar DE TAIWÁN|55QUETZAL (GUATEMALTECOS)|56FORINT (HUNGRIA)|57BAHT (TAILANDIA)|58ECU|59DINAR KUWAITI|60EURO|61ZLTYS POLACOS|62RUPIAS HINDÚES|63LEMPIRAS HONDUREÑAS|' "/>
<xsl:variable name="monedas" select=" '0Otras Monedas|PES$|DOLU$S|2U$S Libre|3&#8355;|4&#8356;|5&#8359;|6DM|7&#402;|8&#8355;|9CHF|10$|11$U|12R$|13$|14kr|15kr|16kr|17öS|18U$S|19&#165;|21&#163;|22FIM|23Bs|24K&#269;|25&#1044;&#1080;&#1085;&#46;|26U$S|27Dracma|28&#402;|29Gs|30&#8362;|31$b|32$|33$|34XXX|35S/.|36U$S|40lei|41D.E.Giro|42RD$|43B/.|44C$|45&#8360;|46&#163;|47Rial|48&#8355;|49gr.Oro|50&#163;|51HK$|52U$S|53J$|54NT$|55Q|56Ft|57&#3647;|58ECU|59KWD|60&#8364;|61z&#322;|62&#8360;|63L|' "/>



<!-- Fin de Variables Diccionario -->

<!-- Codigo que transforma los numeros en palabras -->

<xsl:template name="int2word">

<xsl:param name="in-integer" select="1"/>
<!-- this is the number you want to convert to a word or words -->
<xsl:variable name="the-number" select="translate($in-integer, ',.', '')"/>
<!-- remove any formatting characters -->
<xsl:variable name="num-length" select="string-length($the-number)"/>
<xsl:variable name="group-length">
	<xsl:choose>
		<xsl:when test="($num-length mod 3) = 0">3</xsl:when>
		<xsl:otherwise>
			<xsl:value-of select="$num-length mod 3"/>
		</xsl:otherwise>
	</xsl:choose>
</xsl:variable>
<xsl:variable name="first-group" select="substring($the-number, 1, $group-length)"/>
<xsl:variable name="the-rest" select="substring($the-number, $group-length + 1, $num-length)"/>
<xsl:choose>
	<xsl:when test="not($the-rest = '')">
		<xsl:call-template name="hundreds2words">
			<xsl:with-param name="group" select="$first-group"/>
		</xsl:call-template>
		<xsl:if test="number($first-group)">
			<xsl:value-of select="concat(substring-before(substring-after($thousands2word, string-length($the-rest)), '|'),' ')"/>
		</xsl:if>
		<xsl:if test="number($the-rest)">
			<xsl:call-template name="int2word">
				<xsl:with-param name="in-integer" select="$the-rest"/>
			</xsl:call-template>
		</xsl:if>
	</xsl:when>
	<xsl:otherwise>
		<xsl:call-template name="hundreds2words">
			<xsl:with-param name="group" select="$first-group"/>
		</xsl:call-template>
	</xsl:otherwise>
</xsl:choose>
</xsl:template>
<!--Every group of three in American numbering is the basis for counting hundreds of - - thousands, millions, etc. -->
<xsl:template name="hundreds2words">
<xsl:param name="group"/>
<xsl:variable name="first-digit" select="substring(number($group), 1, 1)"/>
<xsl:variable name="remaining-digits">
	<xsl:choose>
		<xsl:when test="(19 &lt; number($group)) and (number($group) &lt; 100) "><xsl:value-of select="substring(number($group), 2, 1)"/></xsl:when>
		<xsl:when test="(99 &lt; number($group)) and (number($group) &lt; 1000) "><xsl:value-of select="substring(number($group), 2, 2)"/></xsl:when>
	</xsl:choose>
</xsl:variable>
<xsl:choose>
	<xsl:when test="not($remaining-digits = '')">
		<xsl:choose>
			<xsl:when test="string-length($remaining-digits) = 1">
				<xsl:choose>
					<xsl:when test="number($remaining-digits) != 0">
						<xsl:value-of select="concat(substring-before(substring-after($tens2word, $first-digit), '|'), '')"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="concat(substring-before(substring-after($tens2word2, $first-digit), '|'), '')"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:when>
			<xsl:when test="string-length($remaining-digits) = 2">
				<xsl:choose>
					<xsl:when test="concat(substring-before(substring-after($int2word, $first-digit), '|'), '') != 'un'">
						<xsl:value-of select="concat(substring-before(substring-after($int2word, $first-digit), '|'), '')"/>
						<xsl:value-of select=" 'cientos ' "/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:choose>
							<xsl:when test="number($remaining-digits) != 0">
								<xsl:value-of select=" 'Ciento ' "/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select=" 'Cien ' "/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:when>
		</xsl:choose>
		<xsl:call-template name="hundreds2words">
			<xsl:with-param name="group" select="number($remaining-digits)"/>
		</xsl:call-template>
	</xsl:when>
	<xsl:otherwise>
		<xsl:choose>
			<xsl:when test="not(number($first-digit))"/>
			<xsl:otherwise>
				<xsl:value-of select="concat(substring-before(substring-after($int2word, number($group)), '|'), ' ')"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:otherwise>
</xsl:choose>
</xsl:template>

<!-- Fin Código que transforma numeros en palabras -->

<!-- Codigos que devuelven el tipo de documento del cliente, Tipo de Factura, Condicion IVA, monedas y jurisdicciones-->

<xsl:template name="coddoc">
	<xsl:param name="correspdocs" select="1"/>
	<xsl:value-of select="substring-before(substring-after($documentos, $correspdocs), '|')"/>
</xsl:template>

<xsl:template name="factu">
	<xsl:param name="correspfactu" select="1"/>
	<xsl:value-of select="substring-before(substring-after($factura, $correspfactu), '|')"/>
</xsl:template>

<xsl:template name="tipofactu">
	<xsl:param name="corresptipofactu" select="1"/>
	<xsl:value-of select="substring-before(substring-after($tipofactura, $corresptipofactu), '|')"/>
</xsl:template>

<xsl:template name="condiva">
	<xsl:param name="correspcondiva" select="1"/>
	<xsl:value-of select="substring-before(substring-after($condicioniva, $correspcondiva), '|')"/>
</xsl:template>

<xsl:template name="codmonedaletras">
	<xsl:param name="codigomonedaletras" select="1"/>
	<xsl:value-of select="substring-before(substring-after($monedasletra, $codigomonedaletras), '|')"/>
</xsl:template>

<xsl:template name="codmoneda">
	<xsl:param name="codigomoneda" select="1"/>
	<xsl:value-of select="substring-before(substring-after($monedas, $codigomoneda), '|')"/>
</xsl:template>

<xsl:template name="codjurisd">
	<xsl:param name="codigojurisdiccion" select="1"/>
	<xsl:value-of select="substring-before(substring-after($jurisdicciones, $codigojurisdiccion), '|')"/>
</xsl:template>



<!-- Fin Codigos que devuelven el tipo de documento del cliente, Tipo de Factura, Condicion IVA, monedas y jurisdicciones-->
			  
	
</xsl:stylesheet>