package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class ServiceITSupport {

    @SerializedName("ServiceITSupportId")
    private Integer serviceITSupportId;
    @SerializedName("ServiceName")
    private String serviceName;
    @SerializedName("Description")
    private String description;
    @SerializedName("CreateDate")
    private String createDate;
    @SerializedName("UpdateDate")
    private String updateDate;

    public Integer getServiceITSupportId() {
        return serviceITSupportId;
    }

    public void setServiceITSupportId(Integer serviceITSupportId) {
        this.serviceITSupportId = serviceITSupportId;
    }

    public String getServiceName() {
        return serviceName;
    }

    public void setServiceName(String serviceName) {
        this.serviceName = serviceName;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getCreateDate() {
        return createDate;
    }

    public void setCreateDate(String createDate) {
        this.createDate = createDate;
    }

    public String getUpdateDate() {
        return updateDate;
    }

    public void setUpdateDate(String updateDate) {
        this.updateDate = updateDate;
    }
}
