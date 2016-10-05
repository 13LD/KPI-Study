<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
      <head>
          <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
      </head>
  <body>
  <h2>Products</h2>
    <table border="4px solid black">
      <tr style="padding-bottom: 1%">
        <th style="text-align:left">Name</th>
        <th style="text-align:left">Price</th>
        <th style="text-align:left">Description</th>
        <th style="text-align:left">Image</th>
      </tr>
      <xsl:for-each select="data/product">
      <tr style="padding-bottom: 1%">
        <td><xsl:value-of select="name"/></td>
        <td><xsl:value-of select="price"/></td>
        <td><xsl:value-of select="description"/></td>
        <td>
            <img height="120px" width="120px">
                <xsl:attribute name="src">
                    <xsl:value-of select="image"/>
                </xsl:attribute>
            </img>
        </td>
      </tr>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>