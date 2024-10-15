package dev.SuiviColis;
import java.io.Serializable;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;

@Entity
public class Colis implements Serializable {
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	
	@Id
	private String trackingNumber;
    private String status;
    private String destination;

    public Colis() {}

    public Colis(String trackingNumber, String status, String destination) {
        this.trackingNumber = trackingNumber;
        this.status = status;
        this.destination = destination;
    }

    public String getTrackingNumber() {
        return trackingNumber;
    }

    public void setTrackingNumber(String trackingNumber) {
        this.trackingNumber = trackingNumber;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }
}

