<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estras003.aspx.cs" Inherits="estras003" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
    <script src="../jquery.js"></script>

    <script src="tinymce.min.js"></script>
	<style> 
		fieldset{
			padding: 10px;
		}
		table.border td, table.border th{
			/*border: 1px solid;*/
			margin: 0;
			padding: 0;
		}
		table.border tr,table.border{
			margin: 0;
			padding: 0;
		}
		.width-100{
			width: 95%;
		}
		.width-50{
			width: 47%;
			float: left;
		}
	</style>
	<script>
	    tinymce.init({
	        selector: 'textarea',
	        language: 'es_MX',
	        language_url: 'langs/es_MX.js',
	        images_upload_url: 'postAcceptor.php',
	        images_upload_base_path: '/some/basepath',
	        images_upload_credentials: true,
	        plugins: [
      		'advlist autolink link image lists charmap preview hr anchor pagebreak spellchecker',
		      'searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking',
		      'save table contextmenu directionality template paste textcolor'
	        ],
	        toolbar: 'insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | preview media fullpage | forecolor backcolor'
	    });
	    // tinymce.activeEditor.uploadImages(function(success) {
	    //   $.post('ajax/post.php', tinymce.activeEditor.getContent()).done(function() {
	    //     console.log("Uploaded images and posted content as an ajax request.");
	    //   });
	    // });


	    $(document).ready(function () {

	        $("#frms003").submit(function (event) {
	            event.preventDefault();
	            if ($("#introduccion").val() == '') {
	                alert("Por favor, ingrese introducción e intente de nuevo");
	            } else {
	                alert("lleno " + $("#introduccion").val());
	                var limit = 5; // word limit
	                var count = $("#introduccion").val().split(' ').length;
	                $('.counter').html(count);
	                if (count > limit) {
	                    alert('Recuerda : Tu texto debe tener máximo 5 palabras!' + count);
	                    return false;
	                } else {
	                    alert("palabras " + count);
	                }
	            }
	        });

	    });

	</script>
	
	<style>
		body{
			font-family: arial;
		}
		.title{
			display: block;
   			margin-bottom: 7px;
		}
		.note{
			font-size: 14px;
			margin-bottom: 5px;
			display:block;
		}
		.red{
			color: red;
			font-size: 16px !important;

		}
	</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Instrumento S003</h2>

     <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>

    <!-- <legend>NOMBRE DE LA ENTIDAD QUE ORGANIZA</legend> -->
	    <table width="100%">
	    	<tr>
	    		<td width="100%" align="center">
    				<br><b>DESARROLLO DEL INFORME DE INVESTIGACIÓN<br></b><br>
	    		</td>
	    	</tr>
	    </table>	    
		<fieldset>
			<table width="100%">
				<tr>
		    		<td width="100%" >
	    				<b class="title">1. INTRODUCCIÓN</b>
	    				<span class="note"><span class="red">*</span>Realice síntesis de máximo 1.000 palabras en el que dé cuenta de los aspectos más importantes de la investigación (planteamientos iniciales, procesos, resultados, alcances y aprendizajes).</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
	    				<textarea  id="introduccion" name="introduccion" style="min-height: 200px"></textarea>
		    		</td>
		    	</tr>
			</table>
		</fieldset><br>
		<fieldset>
			<table width="100%">
				<tr>
		    		<td width="100%">
	    				<b class="title">2. OBJETIVOS</b><br>
	    				<b class="title">2.1. OBJETIVO GENERAL</b>
	    				<span class="note"><span class="red">*</span>Trascriba el propósito final de su investigación que planteó cuando diseño las trayectorias de indagación.</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
	    				<textarea  id="objetivogeneral" name="objetivogeneral" style="min-height: 200px"></textarea>
		    		</td>
		    	</tr>

		    	<tr><td><br></td></tr>

		    	<tr>
		    		<td>
		    			<b class="title">2.2. OBJETIVOS ESPECIFICOS</b>
		    			<span class="note"><span class="red">*</span>Escriba los alcances esperados de la investigación relacionado en los segmentos de investigación.</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
	    				<textarea  id="objetivosespeficios" name="objetivosespeficios" style="min-height: 200px"></textarea>
		    		</td>
		    	</tr>
			</table>
		</fieldset><br>
		<!-- 3.	PERTURBACIÓN DE LA ONDA -->
		<fieldset>
			<table width="100%">
				<tr>
		    		<td width="100%">
	    				<b class="title">3.	PERTURBACIÓN DE LA ONDA</b>
	    				<span class="note"><span class="red">*</span>Escriba la pregunta de investigación del proyecto y el proceso con el cual que llegaron a ella. (Máximo 100 palabras).</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
	    				<textarea  id="perturbaciondelaonda" name="perturbaciondelaonda" style="min-height: 200px"></textarea>
		    		</td>
		    	</tr>
			</table>
		</fieldset><br>

		<!-- 4.	SUPERPOSICIÓN DE LA ONDA-->
		<fieldset>
			<table width="100%">
				<tr>
		    		<td width="100%">
	    				<b class="title">4.	SUPERPOSICIÓN DE LA ONDA</b>
	    				<span class="note"><span class="red">*</span>Indiquen la problemática que aborda la investigación (En máximo 300 palabras).</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
	    				<textarea  id="superposiciondelaonda" name="superposiciondelaonda" style="min-height: 200px"></textarea>
		    		</td>
		    	</tr>
			</table>
		</fieldset><br>

		<!-- 5.	TRAYECTORIA DE LA INDAGACIÓN-->
		<fieldset>
			<table width="100%">
				<tr>
		    		<td width="100%">
	    				<b class="title">5.	TRAYECTORIA DE LA INDAGACIÓN</b>
	    				<span class="note"><span class="red">*</span>(máximo 2.000 palabras).</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
                        <p style="text-align: left;">Explique:</p>
							<p style="text-align: left;">&bull; Explique la metodolog&iacute;a utilizada. Incluya datos estad&iacute;sticos si se tienen.</p>
							<p style="text-align: left;">&bull; Describa el recorrido de la investigaci&oacute;n para responder la pregunta y el problema.</p>
							<p style="text-align: left;">&bull; Explique los conceptos o ideas centrales que orientaron la investigaci&oacute;n.</p>
	    				<textarea  id="trayectoriadelaindagacion" name="trayectoriadelaindagacion" style="min-height: 200px">
						</textarea>
		    		</td>
		    	</tr>
			</table>
		</fieldset><br>

		<!-- 6.	REFLEXION DE LA ONDA -->
		<fieldset>
			<table width="100%">
				<tr>
		    		<td width="100%">
	    				<b class="title">6.	REFLEXION DE LA ONDA</b>
	    				<span class="note"><span class="red">*</span>(máximo 2.000 palabras)</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
                        <p style="text-align: left;">Presenten los resultados y conclusiones de la investigación desarrollando:</p>
							<p style="text-align: left;">&bull; Contenidos</p>
							<p style="text-align: left;">&bull; Procesos</p>
							<p style="text-align: left;">&bull; Aprendizajes</p>
							<p style="text-align: left;">&bull; Espacios de apropiación en los cuales se hayan presentado avances o resultados del proyecto, indicando los medios propuestos y utilizados para la divulgación del proyecto, así como sus resultados.</p>
							<p style="text-align: left;">Puede apoyar el texto con cuadros, gráficas, estadísticas o fotografías, todo ello indicando las fuentes respectivas.</p>
	    				<textarea  id="reflexiondelaonda" name="reflexiondelaonda" style="min-height: 200px">
						</textarea>
		    		</td>
		    	</tr>
			</table>
		</fieldset><br>

		<!-- 7.	BIBLIOGRAFÍA Y FUENTES -->
		<fieldset>
			<table width="100%">
				<tr>
		    		<td width="100%">
	    				<b class="title">7.	BIBLIOGRAFÍA Y FUENTES</b>
	    				<span class="note"><span class="red">*</span>Relación de las fuentes de consulta más relevante de su investigación debidamente citada, normas APA</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
	    				<textarea  id="bibliografiayfuentes" name="bibliografiayfuentes" style="min-height: 200px"></textarea>
		    		</td>
		    	</tr>
			</table>
		</fieldset><br>

		<!-- 8.	ANEXOS Y EVIDENCIAS -->
		<fieldset >
			<table width="100%">
				<tr>
		    		<td width="100%">
	    				<b class="title">8.	ANEXOS Y EVIDENCIAS</b>
	    				<span class="note"><span class="red">*</span>Recuerde en cada fotografía que anexe como evidencia, debe el pie de foto respectivo</span>
		    		</td>
		    	</tr>
		    	<tr>
		    		<td width="100%" align="center">
	    				<textarea  id="anexosyevidencias" name="anexosyevidencias" style="min-height: 200px"></textarea>
		    		</td>
		    	</tr>
			</table>
		</fieldset>	
		<br><br><br><br>
		<style>
			.button{
				background: rgba(0,0,0,.7);
			    bottom: 0;
			    display: block;
			    left: 0;
			    padding: 15px;
			    position: fixed;
			    right: 0;
			    text-align: right;
			}
		</style>

		<div class="button">
			<input type="submit" value="Guardar todo" class="btn btn-success">
            <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-primary" Text="Regresar" OnClick="btnRegresar_Click" />
		</div>

</asp:Content>

