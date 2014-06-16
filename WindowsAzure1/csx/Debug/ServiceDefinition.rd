<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WindowsAzure1" generation="1" functional="0" release="0" Id="c223cd3b-e516-4adc-b3d7-15626a056f55" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WindowsAzure1Group" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WCF:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzure1/WindowsAzure1Group/LB:WCF:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="WebRole1:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzure1/WindowsAzure1Group/LB:WebRole1:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WCF:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzure1/WindowsAzure1Group/MapWCF:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WCFInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzure1/WindowsAzure1Group/MapWCFInstances" />
          </maps>
        </aCS>
        <aCS name="WebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzure1/WindowsAzure1Group/MapWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebRole1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzure1/WindowsAzure1Group/MapWebRole1Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WCF:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzure1/WindowsAzure1Group/WCF/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:WebRole1:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzure1/WindowsAzure1Group/WebRole1/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWCF:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzure1/WindowsAzure1Group/WCF/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWCFInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzure1/WindowsAzure1Group/WCFInstances" />
          </setting>
        </map>
        <map name="MapWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzure1/WindowsAzure1Group/WebRole1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWebRole1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzure1/WindowsAzure1Group/WebRole1Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WCF" generation="1" functional="0" release="0" software="C:\Users\Yader\documents\visual studio 2013\Projects\WindowsAzure1\WindowsAzure1\csx\Debug\roles\WCF" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WCF&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WCF&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;WebRole1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="WCF.svclog" defaultAmount="[1000,1000,1000]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzure1/WindowsAzure1Group/WCFInstances" />
            <sCSPolicyUpdateDomainMoniker name="/WindowsAzure1/WindowsAzure1Group/WCFUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WindowsAzure1/WindowsAzure1Group/WCFFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="WebRole1" generation="1" functional="0" release="0" software="C:\Users\Yader\documents\visual studio 2013\Projects\WindowsAzure1\WindowsAzure1\csx\Debug\roles\WebRole1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="8080" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WebRole1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WCF&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;WebRole1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzure1/WindowsAzure1Group/WebRole1Instances" />
            <sCSPolicyUpdateDomainMoniker name="/WindowsAzure1/WindowsAzure1Group/WebRole1UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WindowsAzure1/WindowsAzure1Group/WebRole1FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WCFUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyUpdateDomain name="WebRole1UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WCFFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="WebRole1FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WCFInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="WebRole1Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="181de076-8682-40cd-a10e-6dd8b4554d24" ref="Microsoft.RedDog.Contract\ServiceContract\WindowsAzure1Contract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="50b28f47-f360-48e7-b90a-6b62409dd8f6" ref="Microsoft.RedDog.Contract\Interface\WCF:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/WindowsAzure1/WindowsAzure1Group/WCF:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="371b6664-5efe-4ae8-8f3c-1d121ad1b295" ref="Microsoft.RedDog.Contract\Interface\WebRole1:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/WindowsAzure1/WindowsAzure1Group/WebRole1:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>