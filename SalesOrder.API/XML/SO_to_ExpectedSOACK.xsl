<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" />

  <!-- Template for transforming Sales Order JSON into Sales Order Acknowledgement format -->
  <xsl:template match="/">
    <ExpectedSalesOrderAcknowledgement>
      <!-- Copy orderRef, internalRef, status, receivedDate -->
      <orderRef>
        <xsl:value-of select="SalesOrder/orderRef" />
      </orderRef>
      <internalRef>
        <xsl:value-of select="SalesOrder/internalRef" />
      </internalRef>
      <status>
        <xsl:value-of select="SalesOrder/status" />
      </status>
      <receivedDate>
        <xsl:value-of select="SalesOrder/receivedDate" />
      </receivedDate>
      <!-- Copy received items -->
      <receivedItems>
        <xsl:for-each select="SalesOrder/receivedItems/item">
          <item>
            <!-- Copy stockCode and qtyReceived -->
            <stockCode>
              <xsl:value-of select="stockCode" />
            </stockCode>
            <qtyReceived>
              <xsl:value-of select="qtyReceived" />
            </qtyReceived>
          </item>
        </xsl:for-each>
      </receivedItems>
    </ExpectedSalesOrderAcknowledgement>
  </xsl:template>
</xsl:stylesheet>
