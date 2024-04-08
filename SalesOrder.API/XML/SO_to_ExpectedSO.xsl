<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" />

  <!-- Template for transforming Sales Order JSON into Expected Sales Order format -->
  <xsl:template match="/">
    <ExpectedSalesOrder>
      <!-- Copy orderRef, orderDate, currency, shipDate, categoryCode -->
      <orderRef>
        <xsl:value-of select="SalesOrder/orderRef" />
      </orderRef>
      <orderDate>
        <xsl:value-of select="SalesOrder/orderDate" />
      </orderDate>
      <currency>
        <xsl:value-of select="SalesOrder/currency" />
      </currency>
      <shipDate>
        <xsl:value-of select="SalesOrder/shipDate" />
      </shipDate>
      <categoryCode>
        <xsl:value-of select="SalesOrder/categoryCode" />
      </categoryCode>
      <!-- Copy addresses -->
      <addresses>
        <xsl:for-each select="SalesOrder/addresses/address">
          <address>
            <!-- Copy addressType, locationNumber, contactName, lastName, companyName, addressLine1, city, state, postcode, countryCode, phoneNumber, emailAddress -->
            <addressType>
              <xsl:value-of select="addressType" />
            </addressType>
            <locationNumber>
              <xsl:value-of select="locationNumber" />
            </locationNumber>
            <contactName>
              <xsl:value-of select="contactName" />
            </contactName>
            <lastName>
              <xsl:value-of select="lastName" />
            </lastName>
            <companyName>
              <xsl:value-of select="companyName" />
            </companyName>
            <addressLine1>
              <xsl:value-of select="addressLine1" />
            </addressLine1>
            <city>
              <xsl:value-of select="city" />
            </city>
            <state>
              <xsl:value-of select="state" />
            </state>
            <postcode>
              <xsl:value-of select="postcode" />
            </postcode>
            <countryCode>
              <xsl:value-of select="countryCode" />
            </countryCode>
            <phoneNumber>
              <xsl:value-of select="phoneNumber" />
            </phoneNumber>
            <emailAddress>
              <xsl:value-of select="emailAddress" />
            </emailAddress>
            <locationNumberQualifier>
              <xsl:value-of select="locationNumberQualifier" />
            </locationNumberQualifier>
          </address>
        </xsl:for-each>
      </addresses>
      <!-- Copy order lines -->
      <lines>
        <xsl:for-each select="SalesOrder/lines/line">
          <line>
            <!-- Copy skuCode, quantity, and description -->
            <skuCode>
              <xsl:value-of select="skuCode" />
            </skuCode>
            <quantity>
              <xsl:value-of select="quantity" />
            </quantity>
            <description>
              <xsl:value-of select="description" />
            </description>
          </line>
        </xsl:for-each>
      </lines>
    </ExpectedSalesOrder>
  </xsl:template>
</xsl:stylesheet>
