library(arules)
library(arulesViz)
library(plyr)
library(ggplot2)

df <- read.csv('cut.csv')

transactionData <- ddply(df,c('KundeID', 'WarenkorbID'),
                         function(df1)paste(df1$ArtikelID,
                                            collapse = ","))

transactionData$KundeID <- NULL
transactionData$WarenkorbID <- NULL

colnames(transactionData) <- c('items')

write.csv(transactionData, 'baskets.csv', quote = FALSE, row.names = FALSE)

tr <- read.transactions('baskets.csv', format = 'basket', sep=',')
summary(tr)

itemFrequencyPlot(tr,topN=20,type="absolute", main="Absolute Item Frequency Plot")

itemFrequencyPlot(tr,topN=20,type="relative", main="Relative Item Frequency Plot")

association.rules <- apriori(tr, parameter = list(supp=0.0001, conf=0.80, maxlen=3, maxtime=100))
inspect(association.rules[1:10])

df.rules = data.frame(
  lhs = labels(lhs(association.rules)),
  rhs = labels(rhs(association.rules)), 
  association.rules@quality)
write.csv(df.rules, 'rules.csv')

