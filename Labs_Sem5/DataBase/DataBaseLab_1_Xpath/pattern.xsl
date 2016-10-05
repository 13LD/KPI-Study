<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <head>
  </head>
  <body>
  <h2>Products</h2>
  <div class="container">
    <xsl:for-each select="data/product">
      <div class="colll" style="margin-bottom: 1%">
        <div class="colll" style="background-color:lavender;">Name : <xsl:value-of select="name"/></div>
        <div class="colll" style="background-color:lavender;">Price : <xsl:value-of select="price"/></div>
        <div class="colll" style="background-color:lavender;">Description : <xsl:value-of select="description"/></div>
        <div class="colll" style="background-color:lavender;">
          <img >
                <xsl:attribute name="src">
                    <xsl:value-of select="image"/>
                </xsl:attribute>
          </img>
        </div>
      </div>

      </xsl:for-each>
    </div>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>