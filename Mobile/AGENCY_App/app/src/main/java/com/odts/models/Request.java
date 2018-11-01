package com.odts.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Request {
    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("agencyId")
    private Integer agencyId;
    @SerializedName("requestCategoryId")
    private Integer requestCategoryId;
    @SerializedName("serviceItemId")
    private Integer serviceItemId;
    @SerializedName("RequestName")
    private String requestName;
    @SerializedName("RequestDesciption")
    private String RequestDesciption;
    @SerializedName("CreateDate")
    private String createDate;
    @SerializedName("UpdateDate")
    private String updateDate;
    @SerializedName("NumberOfTicket")
    private Integer nod;
    @SerializedName("Ticket")
    private List<Ticket> ticket;
    @SerializedName("RequestStatus")
    private Integer status;

    public Request() {
    }

//    public Request(String requestName, String createDate, String updateDate) {
//        this.requestName = requestName;
//        this.createDate = createDate;
//        this.updateDate = updateDate;
//    }

    public Integer getStatus() {
        return status;
    }

    public void setStatus(Integer status) {
        this.status = status;
    }

    public String getUpdateDate() {
        return updateDate;
    }

    public void setUpdateDate(String updateDate) {
        this.updateDate = updateDate;
    }

    public Integer getNod() {
        return nod;
    }

    public void setNod(Integer nod) {
        this.nod = nod;
    }

    public Integer getRequestId() {
        return requestId;
    }

    public void setRequestId(Integer requestId) {
        this.requestId = requestId;
    }

    public String getCreateDate() {
        return createDate;
    }

    public void setCreateDate(String createDate) {
        this.createDate = createDate;
    }

    public Integer getAgencyId() {
        return agencyId;
    }

    public void setAgencyId(Integer agencyId) {
        this.agencyId = agencyId;
    }

    public Integer getRequestCategoryId() {
        return requestCategoryId;
    }

    public void setRequestCategoryId(Integer requestCategoryId) {
        this.requestCategoryId = requestCategoryId;
    }

    public Integer getServiceItemId() {
        return serviceItemId;
    }

    public void setServiceItemId(Integer serviceItemId) {
        this.serviceItemId = serviceItemId;
    }

    public String getRequestName() {
        return requestName;
    }

    public void setRequestName(String requestName) {
        this.requestName = requestName;
    }

    public String getRequestDesciption() {
        return RequestDesciption;
    }

    public void setRequestDesciption(String requestDesciption) {
        RequestDesciption = requestDesciption;
    }

    public List<Ticket> getTicket() {
        return ticket;
    }

    public void setTicket(List<Ticket> ticket) {
        this.ticket = ticket;
    }

}
