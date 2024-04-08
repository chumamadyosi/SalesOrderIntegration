<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes"/>

  <!-- Template to match the root element -->
  <xsl:template match="/">
    <SalesOrderAcknowledgement>
      <!-- Copy orderRef, internalRef, status, and other elements from JSON -->
      <xsl:apply-templates select="orderAcknowledgement"/>
    </SalesOrderAcknowledgement>
  </xsl:template>

  <!-- Template to match the orderAcknowledgement element -->
  <xsl:template match="orderAcknowledgement">
    <OrderAcknowledgement>
      <OrderRef>
        <xsl:value-of select="orderRef"/>
      </OrderRef>
      <InternalRef>
        <xsl:value-of select="internalRef"/>
      </InternalRef>
      <!-- Add more elements as needed -->
    </OrderAcknowledgement>
  </xsl:template>

  <!-- Add more templates as needed for other elements -->
</xsl:stylesheet>
